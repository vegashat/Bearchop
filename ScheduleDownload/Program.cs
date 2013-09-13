using Bearchop.Core.Services;
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
            Import();
            
        }

        private static void Download()
        {
            var startDate = DateTime.Parse("2013-08-15");
            var endDate = DateTime.Parse("2013-12-10");
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

            Console.ReadLine();
        }
        
        internal class GameDate
        {
            public string AwayTeamName { get; set; }
            public string AwayTeamCity { get; set; }
            public string HomeTeamName { get; set; }
            public string HomeTeamCity { get; set; }
            public DateTime Date { get; set; }
            public string AwayTeam { 
                get {
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
                               Date = DateTime.Parse(s.Element("date").Attribute("year") .Value+ "-" + s.Element("date").Attribute("month").Value + "-" + s.Element("date").Attribute("date").Value)
                           };

               
                foreach(var game in games)
                {
                    var homeTeamId = scheduleService.AddTeam(game.HomeTeamCity);
                    var awayTeamId = scheduleService.AddTeam(game.AwayTeamCity);

                    scheduleService.AddSchedule(homeTeamId, awayTeamId, game.Date);
                }
            }

            Console.ReadLine();
        }
    }
}
