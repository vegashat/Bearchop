using System;
using System.Collections.Generic;
using System.Linq;

namespace Bearchop.LOTW.Core.Models
{
    public partial class LOTWUser
    {
        public LOTWUser()
        {
            this.Picks = new List<Pick>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public virtual ICollection<Pick> Picks { get; set; }

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
