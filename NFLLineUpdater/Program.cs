using Bearchop.LOTW.Core.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NFLLineUpdater
{
    public class Program
    {

        const string NFL_GAME_RESULT = @"http://feeds.foxsports.com/nuggetv2/30_{0}";
        static void Main(string[] args)
        {
            //DownloadLatestLine();
            //CreateGameList();
            UpdateGames();
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


        private static void UpdateGames()
        {
            WeekService weekService = new WeekService();
            SeasonService seasonService = new SeasonService();
            GameService gameService = new GameService();

            var weekNumber = weekService.GetWeek().Number;

            var currentGames = seasonService.GetSchedules(weekNumber);

            foreach(var game in currentGames.Where(g => g.ScoreFinalized == false))
            {

                var uri = new Uri(string.Format(NFL_GAME_RESULT,game.GameCode));

                string fileName = string.Format("{0}.xml", game.GameCode);

                new WebClient().DownloadFile(uri, fileName);

                var data = File.ReadAllText(fileName);
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
                //Find the teams
                var homeTeam = teamService.GetTeam(game.HomeTeam);
                var awayTeam = teamService.GetTeam(game.AwayTeam);

                //Find schedule
                var schedule = seasonService.GetSchedule(weekNumber, homeTeam.Id, awayTeam.Id);

                schedule.HomeTeamSpread = decimal.Parse(game.HomeTeamSpread);
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
