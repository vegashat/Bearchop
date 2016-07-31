using Bearchop.Core.Services;
using Bearchop.LOTW.Core.Models;
using Bearchop.LOTW.Core.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ScheduleDownload
{
    class Program
    {
        static void Main(string[] args)
        {

            //Download();
            //Import();

            //DownloadNFL();
            //ImportNFL();

            Console.WriteLine("All Finished, hit any key to exit");
            Console.ReadLine();

        }

        private static void Download()
        {
            var startDate = DateTime.Parse("2015-08-15");
            var endDate = DateTime.Parse("2015-12-15");
            string dateFormat = "{0}_{1}_{2}";

            string baseUrl = "http://msn.foxsports.com/nuggetv2/16010_"; //2013_8_31

            while (startDate < endDate)
            {
                var fileName = string.Format(dateFormat, startDate.Year, startDate.Month, startDate.Day);
                var thisDaysUrl = string.Concat(baseUrl, fileName);

                WebClient client = new WebClient();

                client.DownloadFile(thisDaysUrl, string.Concat(fileName, ".xml"));
                Console.WriteLine("downloaded : " + thisDaysUrl);
                startDate = startDate.AddDays(1);
            }

        }

        

        private static void DownloadNFL()
        {
            var startDate = DateTime.Parse("2014-08-15");
            var endDate = DateTime.Parse("2015-1-15");
            string dateFormat = "{0}_{1}_{2}";

            string baseUrl = "http://msn.foxsports.com/nuggetv2/16006_"; //2013_8_31

            while (startDate < endDate)
            {
                var fileName = string.Format(dateFormat, startDate.Year, startDate.Month, startDate.Day);
                var thisDaysUrl = string.Concat(baseUrl, fileName);

                WebClient client = new WebClient();

                client.DownloadFile(thisDaysUrl, string.Concat(fileName, "_NFL.xml"));
                Console.WriteLine("downloaded : " + thisDaysUrl);
                startDate = startDate.AddDays(1);
            }

        }

        internal class GameDate
        {
            public string AwayTeamName { get; set; }
            public string AwayTeamCity { get; set; }
            public string HomeTeamName { get; set; }
            public string HomeTeamCity { get; set; }

            public string GameCode { get; set; }
            public DateTime Date { get; set; }
            public string AwayTeam
            {
                get
                {
                    return AwayTeamCity + " " + AwayTeamName;
                }
            }
            public string HomeTeam
            {
                get
                {
                    return HomeTeamCity + " " + HomeTeamName;
                }
            }
        }

        private static void Import()
        {
            ScheduleService scheduleService = new ScheduleService();

            var files = Directory.GetFiles(".", "*.xml");

            foreach (var file in files)
            {
                Console.WriteLine(file);

                var scheduleFile = XDocument.Load(file);

                var games = from s in scheduleFile.Descendants("game-schedule")
                            select new GameDate()
                            {
                                AwayTeamName = s.Element("visiting-team").Element("team-name").Attribute("name").Value,
                                AwayTeamCity = s.Element("visiting-team").Element("team-city").Attribute("city").Value,
                                HomeTeamName = s.Element("home-team").Element("team-name").Attribute("name").Value,
                                HomeTeamCity = s.Element("home-team").Element("team-city").Attribute("city").Value,
                                GameCode = s.Element("gamecode").Attribute("code").Value,
                                Date = DateTime.Parse(s.Element("date").Attribute("year").Value + "-" + s.Element("date").Attribute("month").Value + "-" + s.Element("date").Attribute("date").Value)
                            };


                foreach (var game in games)
                {
                    var homeTeamId = scheduleService.AddTeam(game.HomeTeamCity);
                    var awayTeamId = scheduleService.AddTeam(game.AwayTeamCity);

                    scheduleService.AddSchedule(homeTeamId, awayTeamId, game.Date, game.GameCode);
                }
            }

        }

        private static void ImportNFL()
        {
            SeasonService seasonService = new SeasonService();
            TeamService teamService = new TeamService();
            WeekService weekService = new WeekService();

            var files = Directory.GetFiles(".", "*_NFL.xml");

            foreach (var file in files)
            {
                Console.WriteLine(file);

                var scheduleFile = XDocument.Load(file);

                var games = from s in scheduleFile.Descendants("game-schedule")
                            select new GameDate()
                            {
                                AwayTeamName = s.Element("visiting-team").Element("team-name").Attribute("name").Value,
                                AwayTeamCity = s.Element("visiting-team").Element("team-city").Attribute("city").Value,
                                HomeTeamName = s.Element("home-team").Element("team-name").Attribute("name").Value,
                                HomeTeamCity = s.Element("home-team").Element("team-city").Attribute("city").Value,
                                GameCode = s.Element("gamecode").Attribute("code").Value,
                                Date = DateTime.Parse(s.Element("date").Attribute("year").Value + "-" + s.Element("date").Attribute("month").Value + "-" + s.Element("date").Attribute("day").Value + ' ' + s.Element("time").Attribute("hour").Value + ':' + s.Element("time").Attribute("minute").Value + ":00")
                            };


                foreach (var game in games.Where(g => g.AwayTeamCity.Length > 0))
                {
                    var homeTeamId = teamService.GetTeamId(game.HomeTeam);
                    var awayTeamId = teamService.GetTeamId(game.AwayTeam);

                    Schedule schedule = new Schedule();
                    schedule.HomeId = homeTeamId;
                    schedule.AwayId = awayTeamId;

                    schedule.Date = DateTime.Parse(game.GameCode.Substring(0, 4) + '-' + game.GameCode.Substring(4, 2) + '-' + game.GameCode.Substring(6, 2) + ' ' + game.Date.Hour + ':' + game.Date.Minute + ':' + game.Date.Second);
                    schedule.GameCode = game.GameCode;

                    schedule.Week = weekService.GetWeek(schedule.Date);

                    schedule = seasonService.SaveSchedule(schedule);
                }
            }

        }
    }
}
