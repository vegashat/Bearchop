using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;

namespace JSONDownloader
{
    class Program
    {
        static void Main(string[] args)
        {

            //var uri = new Uri(@"http://www.sportsinsights.net/dataservice/mobilehandler.ashx?_dc=1407209179218&yesterday=false&sport=NFL&userKey=95698ed1-60eb-4b2c-b2d1-7c2581a1cfde&task=Games.Get&isMyGame=false&eventOption=0&page=1&start=0&limit=25&callback=Ext.data.JsonP.callback11");

            //new WebClient().DownloadFile(uri, "lines.json");

            var data = File.ReadAllText("lines.json");

            data = data.Replace("Ext.data.JsonP.callback11(", string.Empty);
            data = data.Replace(");", string.Empty);

            var gameDay = (Day)(JsonConvert.DeserializeObject(data, typeof(Day)));

            foreach(var game in gameDay.Games)
            {
                Console.WriteLine("Home Team : {0}", game.HomeTeam);
                Console.WriteLine("Away Team : {0}", game.VisitorTeam);
                Console.WriteLine("Line 1 : {0}", game.Line1);
                Console.WriteLine("Line 2 : {0}", game.Line2);
                Console.WriteLine("Spread : {0}", game.Spread);
                Console.WriteLine("O/U : {0}", game.OverUnder);
            }

            Console.ReadLine();


        }

        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }

    public class Day
    {
        public List<Game> Games { get; set; }
    }

    public class Game
    {
        public int EventId { get; set; }
        public int Sort { get; set; }
        public string HomeTeam { get; set; }
        public string VisitorTeam { get; set; }

        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public bool HasPick { get; set; }
        public string HomePitcher { get; set; }
        public string VisitorPitcher { get; set; }
        public string Group { get; set; }

        public DateTime GameDate
        {
            get
            {
                var date = Group.Split('-')[1].Trim();
                return DateTime.Parse(date);
            }

        }

        public decimal OverUnder
        {
            get
            {
                if(Line1 == null && Line2 == null)
                {
                    return 0.0m;
                }

                var unformattedLine = Line2;
                //Line1/line2 have either the spread or over/under
                //find the one with the over under and use the other.
                if(Line1.Contains('u') || Line1.Contains('o'))
                {
                    unformattedLine = Line1;
                }

                var indexOfChar = unformattedLine.IndexOf('u');
                if(indexOfChar == -1)
                {
                    indexOfChar = unformattedLine.IndexOf('o');
                }

                if(indexOfChar == -1)
                {
                    return 0.0m;
                }

                unformattedLine = unformattedLine.Substring(0, indexOfChar);
                
                return decimal.Parse(unformattedLine);                
            }
        }

        public decimal Spread 
        {

            get
            {
                if (Line1 == null && Line2 == null)
                {
                    return 0.0m;
                }

                var unformattedLine = Line1;
                //Line1/line2 have either the spread or over/under
                //find the one with the over under and use the other.
                if (Line1.Contains('u') || Line1.Contains('o'))
                {
                    unformattedLine = Line2;
                }

                if (unformattedLine.Length > 4)
                {
                    unformattedLine = unformattedLine.Substring(0, unformattedLine.Length - 4);
                }

                return decimal.Parse(unformattedLine);   
            }
        }

        public bool MyGame { get; set; }
        public int HasPitcher { get; set; }
        public string Pct1 { get; set; }
        public string Pct2 { get; set; }

        public string Line2 { get; set; }

        public string Line1 { get; set; }

        public string LineOpener2 { get; set; }
        public string LineOpener1 { get; set; }
    }
}
