using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NCAAF.Model.Models;


namespace Import
{
    public class Program
    {
        static void Main(string[] args)
        {

            //LoadNCAA();
            LoadNFL();

        }
        private static void LoadNCAA()
        {
            NCAAF.Model.Models.NCAAFContext context = new NCAAF.Model.Models.NCAAFContext();


            var completeSchedule = File.ReadAllLines(@"C:\Users\Public\Documents\schedule.csv");

            using (var writer = File.CreateText("teams not found.txt"))
            {

                foreach (var day in completeSchedule)
                {
                    var schedule = day.Split(',');

                    if (schedule[0].ToString() == "GAME DATE")
                        continue;

                    var date = DateTime.Parse(schedule[0]);
                    var awayTeam = schedule[1].ToString();
                    var homeTeam = schedule[2].ToString();

                    //find home team

                    var home = context.Teams.FirstOrDefault(t => t.Name.ToUpper() == homeTeam.ToUpper());

                    var away = context.Teams.FirstOrDefault(t => t.Name.ToUpper() == awayTeam.ToUpper());

                    if (home == null)
                    {
                        writer.WriteLine(homeTeam);
                    }

                    if (away == null)
                    {
                        writer.WriteLine(awayTeam);
                    }


                    var ncaaSchedule = new NCAAF.Model.Models.Schedule();

                    ncaaSchedule.HomeTeamId = home.TeamId;
                    ncaaSchedule.AwayTeamId = away.TeamId;
                    ncaaSchedule.Date = date;
                    ncaaSchedule.Week = context.Weeks.FirstOrDefault(w => w.BeginDate <= date && w.EndDate >= date).Number;

                    context.Schedules.Add(ncaaSchedule);
                    context.SaveChanges();
                }
            }
        }
    
        private static void LoadNFL()
        {

            Contests.LOTW.Core.Repository.LOTWContext context = new Contests.LOTW.Core.Repository.LOTWContext();

            var completeSchedule = File.ReadAllLines(@"C:\_git\Bearchop\nfl schedules.csv");

            using (var writer = File.CreateText("teams not found.txt"))
            {

                foreach (var day in completeSchedule)
                {
                    var schedule = day.Split(',');

                    if (schedule[0].ToString() == "GAME DATE")
                        continue;

                    var date = DateTime.Parse(schedule[0]);
                    var week = Int32.Parse(schedule[1]);
                    var awayTeam = schedule[2].ToString();
                    var homeTeam = schedule[3].ToString();

                    //find home team

                    var home = context.Teams.FirstOrDefault(t => t.Name.ToUpper() == homeTeam.ToUpper());

                    var away = context.Teams.FirstOrDefault(t => t.Name.ToUpper() == awayTeam.ToUpper());

                    if (home == null)
                    {
                        writer.WriteLine(homeTeam);
                    }

                    if (away == null)
                    {
                        writer.WriteLine(awayTeam);
                    }


                    var nflSchedule = new Contests.LOTW.Core.Model.Schedule();

                    var existingSchedule = context.Schedules.FirstOrDefault(s => s.HomeId == home.Id && s.AwayId == away.Id && s.Date == date);

                    if (existingSchedule == null)
                    {
                        nflSchedule.HomeId = home.Id;
                        nflSchedule.AwayId = away.Id;
                        nflSchedule.Date = date;
                        nflSchedule.Week = context.Weeks.FirstOrDefault(w => w.BeginDate <= date && w.EndDate >= date);

                        context.Schedules.Add(nflSchedule);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
