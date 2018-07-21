using Bearchop.Core.Services;
using FoxSports.Api.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace FoxSportsNCAAFScheduleDownloader
{

    
    class Program
    {
        const string FOX_SCHEDULE_API = @"/sportsdata/v1/football/cfb/events.json?seasontype=reg&timestamp=true&enable=odds&week={0}&group=2&season=2017&apikey=a9OrJWqhOXBP1wjZkhLEcRf8bm25CU4a&skip={1}";
        const string FOX_RESULT_API = "http://api.foxsports.com/v1/content/json?tag=sports:football/leagues/cfb&gameId={0}";
        static void Main(string[] args)
        {
            //DownloadSchedules();
            ProcessSchedules();
            //ProcessGameId();
            ReadLine();
            
        }


        static void DownloadSchedules()
        {
            int week = 1;

            while (week < 16)
            {
                var schedule = DownloadSchedule(week).Result;

                WriteLine("{0} - {1}", week, schedule.page.Count());

                var fileName = $"schedule_{week}.txt";

                using (var file = File.CreateText(fileName))
                {
                    var jsonString = JsonConvert.SerializeObject(schedule);
                    file.Write(jsonString);
                }

                Console.WriteLine($"Processed week {week}");
                week++;
            }
        }

        static void ProcessSchedules()
        {
            ScheduleService scheduleService = new ScheduleService();

            int week = 1;

            while (week < 16)
            {
                var jsonString = File.ReadAllText($"schedule_{week}.txt");
                var settings = new JsonSerializerSettings();
               
                var schedule = JsonConvert.DeserializeObject<Schedule>(jsonString);

                foreach(var game in schedule.page )
                {
                    var homeTeamId = scheduleService.AddTeam(game.homeTeam.customName == null ? game.homeTeam.location : game.homeTeam.customName);
                    var awayTeamId = scheduleService.AddTeam(game.awayTeam.customName == null ? game.awayTeam.location : game.awayTeam.customName );

                    var gameDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(game.utcDate).Date;

                    scheduleService.AddSchedule(homeTeamId, awayTeamId, gameDate, game.id.ToString());
                }
                Console.WriteLine($"Processed week {week}");
                week++;
            }
        }
        private static void ProcessGameId()
        {
            ScheduleService scheduleService = new ScheduleService();

            int week = 1;

            while (week < 16)
            {
                var jsonString = File.ReadAllText($"schedule_{week}.txt");
                var settings = new JsonSerializerSettings();

                var schedule = JsonConvert.DeserializeObject<Schedule>(jsonString);

                foreach(var game in schedule.page)
                {
                    var newGameCode = game.id.ToString();
                    var oldGameCode = game.links.api.content_json.Substring(game.links.api.content_json.Length - 7);
                    WriteLine($"{oldGameCode} - { newGameCode}");

                    scheduleService.UpdateCode(oldGameCode, newGameCode);

                }
                week++;

            }
        }
       
        static async Task<Schedule> DownloadSchedule(int week)
        {
            using(HttpClient client = new HttpClient())
            {
                Schedule schedule = null;
                
                int skip = 0, totalCount = 1;

                client.BaseAddress = new Uri("http://api.foxsports.com");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                while (skip < totalCount)
                {
                    var apiUri = string.Format(FOX_SCHEDULE_API, week, skip);
                    HttpResponseMessage response = await client.GetAsync(apiUri);
                    if (response.IsSuccessStatusCode)
                    {
                        var scheduleJson = JsonConvert.DeserializeObject<Schedule>(await response.Content.ReadAsStringAsync());

                        if (schedule == null)
                        {
                            schedule = scheduleJson;
                        }
                        else
                        {
                            schedule.page.AddRange(scheduleJson.page);
                        }
                    
                        totalCount = scheduleJson.totalCount;
                        skip = scheduleJson.currentPageStart;

                        if(totalCount - skip > scheduleJson.pageSize )
                        {
                            skip += scheduleJson.pageSize;
                        }
                        else
                        {
                            skip = totalCount;
                        }
                    }
                }

                return schedule;
            }

            
        }
    }
}
