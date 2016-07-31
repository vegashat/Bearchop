using Bearchop.Core.Models;
using Bearchop.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NCAAFUpdater
{
    class Program
    {

        internal class GameResult
        {
            public string GameCode { get; set; }
            public int Week { get; set; }
            public TeamResult HomeTeam { get; set; }
            public TeamResult VisitingTeam { get; set; }
            public bool IsFinal { get; set; }
        }

        internal class TeamResult
        {
            public string Team { get; set; }
            public short TeamId { get; set; }
            public bool WonGame { get; set; }
            public short RushingYards { get; set; }
            public short PassingYards { get; set; }

            public short Fumbles { get; set; }
            public short Interceptions { get; set; }

            public short Turnovers
            {
                get
                {
                    return (short)((short)Fumbles + (short)Interceptions);
                }
            }
            public short TurnoversForced { get; set; }

            public short PassingYardsAllowed { get; set; }
            public short RushingYardsAllowed { get; set; }
            public short PointsAllowed { get; set; }
            public short PointsScored { get; set; }
            public short Points
            {
                get
                {
                    short points = (short)(PointsScored > 0 ? PointsScored : -3);

                    points += (short)(PointsAllowed > 0 ? 0 : 3);

                    points += (short)(RushingYards >= 300 ? 5 : 0);
                    points += (short)(PassingYards >= 300 ? 5 : 0);

                    points += (short)(RushingYardsAllowed <= 100 ? 5 : 0);
                    points += (short)(PassingYardsAllowed <= 100 ? 5 : 0);

                    points -= Turnovers;

                    points += TurnoversForced;

                    points += (short)(WonGame ? 5 : -5);

                    return points;
                }
            }


        }
        static void Main(string[] args)
        {
            int? weekNumber = null;
            if (args.Length == 1)
            {
                weekNumber = Int32.Parse(args[0]);
            }

            var results = StatsImport(weekNumber);
            ProcessResults(results);
        }

        private static IEnumerable<GameResult> StatsImport(int? weekNumber)
        {
            ScheduleService scheduleService = new ScheduleService();
            NCAAFWeekService weekService = new NCAAFWeekService();

            List<int> teamsNotUpdated = new List<int>();

            var week = weekService.GetWeek(weekNumber);

            var schedules = scheduleService.GetSchedules(true, true, week.Number);

            List<GameResult> results = new List<GameResult>();

            foreach (var schedule in schedules)
            {
                //Only process today's games....should probably do this in sql
                if(schedule.Date > DateTime.Today)
                {
                    continue;
                }

                var gameResults = DownloadGameResults(schedule.GameCode);

                if(gameResults.Length < 100)
                {
                    Console.WriteLine("Error - {0}", schedule.GameCode);

                    teamsNotUpdated.Add(schedule.HomeTeamId);
                    teamsNotUpdated.Add(schedule.AwayTeamId);

                    continue;
                }

                var xml = XDocument.Parse(gameResults);

                var status = (from s in xml.Descendants("gametrax")
                              select s.Element("game").Element("gamestate").Attribute("status").Value).First();

                //No processing if the game hasn't started
                if(status == "Pre-Game")
                {
                    continue;
                }

                GameResult result = new GameResult() { GameCode = schedule.GameCode, Week = week.Number };

                TeamResult visitingTeam = (from g in xml.Descendants("gametrax")
                                           select new TeamResult()
                                           {
                                               PassingYards = Int16.Parse(g.Element("game").Element("team-stats").Element("visiting-team-stats").Element("passing").Attribute("net-yards").Value),
                                               RushingYards = Int16.Parse(g.Element("game").Element("team-stats").Element("visiting-team-stats").Element("rushing").Attribute("yards").Value),
                                               Fumbles = Int16.Parse(g.Element("game").Element("team-stats").Element("visiting-team-stats").Element("fumbles").Attribute("lost").Value),
                                               Interceptions = Int16.Parse(g.Element("game").Element("team-stats").Element("visiting-team-stats").Element("passing").Attribute("interceptions").Value)
                                           }).First();

                TeamResult homeTeam = (from g in xml.Descendants("game")
                                       select new TeamResult()
                                       {
                                           PassingYards = Int16.Parse(g.Element("team-stats").Element("home-team-stats").Element("passing").Attribute("net-yards").Value),
                                           RushingYards = Int16.Parse(g.Element("team-stats").Element("home-team-stats").Element("rushing").Attribute("yards").Value),
                                           Fumbles = Int16.Parse(g.Element("team-stats").Element("home-team-stats").Element("fumbles").Attribute("lost").Value),
                                           Interceptions = Int16.Parse(g.Element("team-stats").Element("home-team-stats").Element("passing").Attribute("interceptions").Value)
                                       }).First();

                visitingTeam.TurnoversForced = homeTeam.Turnovers;
                homeTeam.TurnoversForced = visitingTeam.Turnovers;

                visitingTeam.RushingYardsAllowed = homeTeam.RushingYards;
                visitingTeam.PassingYardsAllowed = homeTeam.PassingYards;

                homeTeam.RushingYardsAllowed = visitingTeam.RushingYards;
                homeTeam.PassingYardsAllowed = visitingTeam.PassingYards;

                visitingTeam.PointsScored = (from s in xml.Descendants("game")
                                             select Int16.Parse(s.Element("visiting-team").Element("linescore").Attribute("score").Value)).First();

                visitingTeam.Team = (from s in xml.Descendants("game")
                                     select s.Element("visiting-team").Element("team-city").Attribute("city").Value + " " + s.Element("visiting-team").Element("team-name").Attribute("name").Value).First();

                homeTeam.PointsScored = (from s in xml.Descendants("game")
                                         select Int16.Parse(s.Element("home-team").Element("linescore").Attribute("score").Value)).First();

                homeTeam.Team = (from s in xml.Descendants("game")
                                 select s.Element("home-team").Element("team-city").Attribute("city").Value + " " + s.Element("home-team").Element("team-name").Attribute("name").Value).First();

                homeTeam.PointsAllowed = visitingTeam.PointsScored;
                visitingTeam.PointsAllowed = homeTeam.PointsScored;

                homeTeam.WonGame = homeTeam.PointsScored > visitingTeam.PointsScored;
                visitingTeam.WonGame = !homeTeam.WonGame;

                result.HomeTeam = homeTeam;
                result.HomeTeam.TeamId = (short)schedule.HomeTeamId;

                result.VisitingTeam = visitingTeam;
                result.VisitingTeam.TeamId = (short)schedule.AwayTeamId;

                result.IsFinal = (from s in xml.Descendants("gametrax")
                                  select s.Element("game").Element("gamestate").Attribute("status").Value).First() == "FINAL";

                results.Add(result);

                Console.WriteLine("{0} - {1}", homeTeam.Team, homeTeam.Points);
                Console.WriteLine("{0} - {1}", visitingTeam.Team, visitingTeam.Points);
            }

            if(teamsNotUpdated.Count > 0)
            {
                if (DateTime.Now.Hour < 9)
                {
                    NotifyOfBadDownload(teamsNotUpdated);
                }
            }

            return results;

            //string fileName = string.Format("week{0}_results.csv",week.Number);

            //if (File.Exists(fileName)
            //{
            //    File.Delete(fileName);
            //}

            //var file = File.CreateText(fileName);

            //file.WriteLine("Team,TeamId, Won Game, Points Scored, Points Allowed, Passing Yards, Rushing Yards, Turnovers Forced, Passing Yards Allowed, Rushing Yards Allowed, Turnovers Allowed, Total Points,Jeaux Total Points");
            //foreach (var result in results)
            //{
            //    var homeTeam = result.HomeTeam;
            //    var visitingTeam = result.VisitingTeam;


            //    var homeTeamJeauxScore = scoringService.GetJeauxResults(homeTeam.TeamId, week.Number);
            //    var visitingTeamJeauxScore = scoringService.GetJeauxResults(visitingTeam.TeamId, week.Number);

            //    file.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}", homeTeam.Team, homeTeam.TeamId, homeTeam.WonGame, homeTeam.PointsScored, homeTeam.PointsAllowed, homeTeam.PassingYards, homeTeam.RushingYards, homeTeam.TurnoversForced, homeTeam.PassingYardsAllowed, homeTeam.RushingYardsAllowed, homeTeam.Turnovers, homeTeam.Points, homeTeamJeauxScore.Points);
            //    file.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}", visitingTeam.Team, visitingTeam.TeamId, visitingTeam.WonGame, visitingTeam.PointsScored, visitingTeam.PointsAllowed, visitingTeam.PassingYards, visitingTeam.RushingYards, visitingTeam.TurnoversForced, visitingTeam.PassingYardsAllowed, visitingTeam.RushingYardsAllowed, visitingTeam.Turnovers, visitingTeam.Points, visitingTeamJeauxScore.Points);
            //}

            //file.Close();

        }

        private static void ProcessResults(IEnumerable<GameResult> results)
        {
            ScheduleService scheduleService = new ScheduleService();

            foreach (var result in results)
            {
                //var homeResult = scoringService.GetJeauxResults(result.HomeTeam.TeamId, result.Week);
                //var visitingResult = scoringService.GetJeauxResults(result.VisitingTeam.TeamId, result.Week);

                //if(homeResult == null)
                //{
                //    homeResult = new Bearchop.Core.Models.COLFOOT_RESULTS();
                //}
                //if(visitingResult == null)
                //{
                //    visitingResult = new Bearchop.Core.Models.COLFOOT_RESULTS();
                //}

                var homeTeam = result.HomeTeam;
                var visitingTeam = result.VisitingTeam;

                SaveResult(result, homeTeam, visitingTeam);
                SaveResult(result, visitingTeam, homeTeam);

                if(result.IsFinal)
                {
                    scheduleService.FinalizeGame(result.GameCode);
                }
            }
        }

        private static void SaveResult(GameResult gameResult, TeamResult team1, TeamResult team2)
        {
            NCAAFScoringService scoringService = new NCAAFScoringService();
            TeamService teamService = new TeamService();

            var result = scoringService.GetJeauxResults(team1.TeamId, gameResult.Week);

            result.TeamID = team1.TeamId;
            result.Name = team1.Team;
            result.Week = (byte)gameResult.Week;
            result.Score = team1.PointsScored;

           

            result.OPass = (short)(team1.PassingYards >= 300 ? 5 : 0);
            result.ORush = (short)(team1.RushingYards >= 300 ? 5 : 0);
            result.DPass = (short)(team1.PassingYardsAllowed <= 100 ? 5 : 0);
            result.DRush = (short)(team1.RushingYardsAllowed <= 100 ? 5 : 0);
            result.TA = team1.Turnovers;
            result.TF = team1.TurnoversForced;
            result.WinLoss = (short)(team1.WonGame ? 5 : -5);

            if (team1.PointsScored == 0)
            {
                result.WinLoss -= 3;
            }

            if (team2.PointsScored == 0)
            {
                result.WinLoss += 3;
            }
            result.Points = team1.Points;

            if(teamService.GetTeam(team1.TeamId) != null)
            {
                scoringService.UpdateResult(result);
            }
        }

        private static string DownloadGameResults(string gameId)
        {
            string baseUrl = @"http://feeds.foxsports.com/nuggetv2/31_";

            var gameUrl = string.Concat(baseUrl, gameId);

            WebClient client = new WebClient();

            var gameResult = client.DownloadData(gameUrl);
            Console.WriteLine("downloaded : " + gameId);

            return System.Text.Encoding.Default.GetString(gameResult);
        }

        private static void NotifyOfBadDownload(List<int> teamsNotUpdated)
        {
            TeamService teamService = new TeamService();

            var fromAddress = new MailAddress("vegashat@gmail.com", "NCAAF Game Updater");
            var toAddress = new MailAddress("im@jeaux.com", "Jeaux Smith");
            //var toAddress = new MailAddress("vegashat@gmail.com", "Chris Albrecht");

            string fromPassword = "alexander0426";
            string subject = "Game Update(s) Failed";

            StringBuilder body = new StringBuilder();

            body.AppendLine("The following teams were not updated:");
            body.AppendLine(string.Empty);
            foreach(var teamId in teamsNotUpdated)
            {
                body.AppendLine(teamService.GetTeam((short)teamId).Name);
            }
            
            var smtp = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body.ToString()
            })
            {
                message.CC.Add(new MailAddress("vegashat@gmail.com","Chris Albrecht"));
                smtp.Send(message);
            }
        }
    }
}
