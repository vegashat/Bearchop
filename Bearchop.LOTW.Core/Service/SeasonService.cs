using Bearchop.LOTW.Core.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bearchop.LOTW.Core.Service
{
    public class SeasonService
    {

        LOTWContext _context = null;

        public SeasonService()
        {
            _context = new LOTWContext();
        }

        public Schedule SaveSchedule(Schedule schedule)
        {
            if(schedule.Id == 0)
            {
                _context.Schedules.Add(schedule);
            }
            else
            {
                _context.Entry(schedule).State = System.Data.Entity.EntityState.Modified;
            }

            _context.SaveChanges();

            return schedule;
        }

        public Schedule GetSchedule(int weekNumber, int homeTeamId, int awayTeamId)
        {
            return _context.Schedules.FirstOrDefault(s => s.Week.Number == weekNumber && s.HomeId == homeTeamId && s.AwayId == awayTeamId);
        }

        public IEnumerable<Schedule> GetSchedules(int weekNumber)
        {
            return _context.Schedules.Where(s => s.Week.Number == weekNumber);
        }
    }
}
