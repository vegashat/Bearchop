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
        static void Main(string[] args)
        {
            var uri = new Uri(@"https://www.kimonolabs.com/api/cvpz3e9q?apikey=LSzFj75rKymrmzBYruhZ4z2xU8HOh9nQ");

            string fileName = string.Format("nfllines_{0}.json", DateTime.Today.ToString("MMddyyyy"));

            new WebClient().DownloadFile(uri, fileName);

        
            var data = File.ReadAllText(fileName);
            var week = (Week)(JsonConvert.DeserializeObject(data, typeof(Week)));
        }
    }


    public class Week
    {
        public int Count { get; set; }

        public Result Results { get; set; }
    }

    public class Result
    {
        public List<Game> Week { get; set; }
    }

    public class  Game
    {
        public string AwayTeam { get; set; }
        public string HomeTeam { get; set; }
        public string OverUnder { get; set; }
        public string HomeTeamSpread { get; set; }
    }

    
}
