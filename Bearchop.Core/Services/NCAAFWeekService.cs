using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bearchop.Core.Models;


namespace Bearchop.Core.Services
{
    public class NCAAFWeekService
    {
        JeauxDBContext _context = new JeauxDBContext();

        public IQueryable<NCAAFootballWeek> GetWeeks()
        {
            return _context.NCAAFootballWeeks.OrderBy(w => w.Number);
        }

        public NCAAFootballWeek GetWeek(int? week = null)
        {                
            if (week.HasValue)
            {
                return _context.NCAAFootballWeeks.FirstOrDefault(w => w.Number == week.Value);
            }
            else
            {
                var now = DateTime.Now;

                var currentWeek = _context.NCAAFootballWeeks.FirstOrDefault(w => w.BeginDate <= now && w.EndDate >= now);

                if (currentWeek == null)
                {
                    currentWeek = _context.NCAAFootballWeeks.FirstOrDefault(w => w.Number == 1);
                }

                return currentWeek;
            }
        }

        public NCAAFootballWeek GetWeek(DateTime date) 
        {
                return _context.NCAAFootballWeeks.FirstOrDefault(w => w.BeginDate <= date && w.EndDate >= date);
            
        }
    }
}
