using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace Bearchop.LOTW.Core.Model
{
    public class LOTWUser
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public IList<Pick> Picks { get; set; }

        public decimal Points
        {
            get
            {
                decimal points = (from p in Picks
                              select p.Points).Sum();

                return points;
            }
        }

        public decimal PointsForWeek(int weekNumber)
        {
            decimal points = (from p in Picks
                          where p.Week.Number == weekNumber
                          select p.Points).Sum();

            return points;
        }
    }
}
