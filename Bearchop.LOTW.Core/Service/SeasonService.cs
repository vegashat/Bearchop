using Bearchop.LOTW.Core.Model;
using Bearchop.LOTW.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bearchop.LOTW.Core.Service
{
    public class SeasonService
    {

        public int GetTeamId(string teamName)
        {
            using(var context = new LOTW.Core.Repository.LOTWContext())
            {
                return context.Teams.FirstOrDefault(t => t.Name == teamName).Id;
            }
        }

        public Schedule SaveSchedule(Schedule schedule)
        {
            using(var context = new LOTWContext())
            {
                if(schedule.Id == 0)
                {
                    context.Schedules.Add(schedule);
                }
                else
                {
                    context.Entry(schedule).State = System.Data.Entity.EntityState.Modified;
                }

                context.SaveChanges();

                return schedule;
            }
        }
    }
}
