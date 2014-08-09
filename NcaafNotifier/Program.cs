using Bearchop.Core.Models;
using Bearchop.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcaafNotifier
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var context = new JeauxDBContext();
            var today = DateTime.Now;
            var scheduleService = new ScheduleService();

            var usersToNotify = context.UserToNotify;

            int week = 1;
            if (args.Length == 1)
            {
                week = Int32.Parse(args[0]);
            }
            else
            {
                week = context.NCAAFootballWeeks.First(w => w.BeginDate <= today && w.EndDate >= today).Number;
            }

            foreach (var user in usersToNotify)
            {
                var userSchedule = scheduleService.GetUserSchedule(user.UserId, week);

                StringBuilder byeWeekMessage = new StringBuilder();

                byeWeekMessage.AppendLine("Current Week is " + week);

                foreach (var teamSchedule in userSchedule.Where(t => t.ByeWeeks.Count > 0))
                {
                    if (teamSchedule.ByeWeeks.Count == 1)
                    {
                        byeWeekMessage.AppendLine(string.Format("{0} has a bye week in week {1}",teamSchedule.TeamInfo.Name, teamSchedule.ByeWeeks.First()));
                    }
                    else
                    {
                        byeWeekMessage.AppendLine(string.Format("{0} has multiple by weeks coming up : {1}",teamSchedule.TeamInfo.Name, string.Join(",", teamSchedule.ByeWeeks)));
                    }

                    if (teamSchedule.SharesByeWeek)
                    {
                        foreach (var byeWeek in teamSchedule.SharedByWeekTeamIds.Keys)
                        {
                            var otherTeamId = teamSchedule.SharedByWeekTeamIds[byeWeek];
                            var otherTeam = userSchedule.AsQueryable().First(s => s.TeamInfo.TeamID == otherTeamId).TeamInfo.Name;

                            byeWeekMessage.AppendLine(string.Format("{0} shares a bye week with {1} on week {2}", teamSchedule.TeamInfo.Name, otherTeam, byeWeek));
                        }
                    }
                }

                Bearchop.Util.Mail.SendMail("Test Schedule", byeWeekMessage.ToString(), "vegashat@gmail.com");

                Console.WriteLine(byeWeekMessage.ToString());
                Console.ReadLine();

            }
        }
    }
}
