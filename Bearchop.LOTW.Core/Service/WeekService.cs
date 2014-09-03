using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bearchop.LOTW.Core.Models;


namespace Bearchop.LOTW.Core.Service
{
    public class WeekService
    {
        LOTWContext context = new LOTWContext();
     
        public IQueryable<Week> GetWeeks()
        {
            return context.Weeks.OrderBy(w => w.Number);
        }

        public Week GetWeek(int? week = null)
        {                
            if (week.HasValue)
            {
                return context.Weeks.FirstOrDefault(w => w.Number == week.Value);
            }
            else
            {
                var now = DateTime.Now;

                var currentWeek = context.Weeks.FirstOrDefault(w => w.BeginDate <= now && w.EndDate >= now);

                if (currentWeek == null)
                {
                    currentWeek = context.Weeks.FirstOrDefault(w => w.Number == 1);
                }

                return currentWeek;
            }
        }

        public Week GetWeek(DateTime date) 
        {
            using(var context = new LOTWContext())
            {
                return context.Weeks.FirstOrDefault(w => w.BeginDate <= date && w.EndDate >= date);
            }
        }
    }
}
