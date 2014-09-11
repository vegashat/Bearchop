using Bearchop.LOTW.Core.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NFLLineUpdater
{
    public class Program
    {
        
        const string NFL_GAME_RESULT = @"http://feeds.foxsports.com/nuggetv2/30_{0}";
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string action = args[0];

                switch(action.ToUpper())
                {
                    case "UPDATELINES":
                        DownloadLatestLine();
                        break;
                    case "UPDATESCORES":
                        UpdateScores();
                        break;
                }
                //DownloadLatestLine();
            }

        }

        
        public static void LogMessage(string message)
        {
            var stream = File.AppendText("log.txt");

            stream.WriteLine(message);
            stream.Close();

        }

        private static void CreateGameList()
        {
            GameService gameService = new GameService();

            var week = new WeekService().GetWeek();

            if (gameService.GetGames(week.Number).Count() == 0)
            {
                gameService.LoadGames(week.Number);
            }
        }


        private static void UpdateScores()
        {
            WeekService weekService = new WeekService();
            SeasonService seasonService = new SeasonService();
            GameService gameService = new GameService();

            var weekNumber = weekService.GetWeek().Number;

            var currentSchedule = seasonService.GetSchedules(weekNumber);

            foreach(var schedule in currentSchedule.Where(g => g.ScoreFinalized == false).ToList())
            {
                if (schedule.Date <= DateTime.Now)
                {
                    var uri = new Uri(string.Format(NFL_GAME_RESULT, schedule.GameCode));

                    string fileName = string.Format("{0}.xml", schedule.GameCode);

                    File.Delete(fileName);

                    new WebClient().DownloadFile(uri, fileName);

                    var data = XDocument.Load(fileName);

                    //Let's update the information
                    var result = data.Descendants("gametrax").Descendants("game").First();
                    var score = new
                    {
                        AwayTeamScore = int.Parse(result.Element("visiting-team").Element("linescore").Attribute("score").Value),
                        HomeTeamScore = int.Parse(result.Element("home-team").Element("linescore").Attribute("score").Value),
                        IsFinalized = result.Element("gamestate").Attribute("status").Value == "FINAL"
                    };

                    

                    if (score.HomeTeamScore > 0 || score.AwayTeamScore > 0)
                    {
                        schedule.HomeTeamScore = score.HomeTeamScore;
                        schedule.AwayTeamScore = score.AwayTeamScore;
                        schedule.ScoreFinalized = score.IsFinalized;

                        seasonService.SaveSchedule(schedule);

                        var game = gameService.GetGame(schedule.GameCode);
                        if (game != null)
                        {
                            game.HomeTeamScore = schedule.HomeTeamScore;
                            game.AwayTeamScore = schedule.AwayTeamScore;

                            game.FinalScore = game.HomeTeamScore + game.AwayTeamScore;

                            gameService.SaveGame(game);
                        }
                    }

                }
            }
        }


        private static void DownloadLatestLine()
        {
            var uri = new Uri(@"https://www.kimonolabs.com/api/cvpz3e9q?apikey=LSzFj75rKymrmzBYruhZ4z2xU8HOh9nQ");

            string fileName = string.Format("nfllines_{0}.json", DateTime.Today.ToString("MMddyyyy"));

            new WebClient().DownloadFile(uri, fileName);

            var data = File.ReadAllText(fileName);
            var currentLines = (Spread)(JsonConvert.DeserializeObject(data, typeof(Spread)));

            //Get the Week
            int weekNumber = int.Parse(currentLines.Results.Week.FirstOrDefault().Value.Split(' ')[1]);

            TeamService teamService = new TeamService();
            SeasonService seasonService = new SeasonService();

            foreach (var game in currentLines.Results.Games)
            {
                LogMessage(string.Format(@"{0} @ {1} with home team spread {2} and over/under {3}", game.AwayTeam, game.HomeTeam, game.HomeTeamSpread,game.OverUnder));
                //Find the teams
                var homeTeam = teamService.GetTeam(game.HomeTeam);
                var awayTeam = teamService.GetTeam(game.AwayTeam);

                //Find schedule
                var schedule = seasonService.GetSchedule(weekNumber, homeTeam.Id, awayTeam.Id);

                schedule.HomeTeamSpread = decimal.Parse(game.HomeTeamSpread.ToUpper() == "EVEN" ? "0" : game.HomeTeamSpread);
                schedule.OverUnder = decimal.Parse(game.OverUnder);

                seasonService.SaveSchedule(schedule);

            }
        }
    }


    public class Spread
    {
        public int Count { get; set; }
        public Result Results { get; set; }
    }

    public class Result
    {
        public List<Game> Games { get; set; }
        public List<Week> Week { get; set; }
    }

    public class Week
    {
        public string Value { get; set; }
    }

    public class  Game
    {
        public string AwayTeam { get; set; }
        public string HomeTeam { get; set; }
        public string OverUnder { get; set; }
        public string HomeTeamSpread { get; set; }
    }

    
}
