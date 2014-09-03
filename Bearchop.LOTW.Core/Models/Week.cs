using System;
using System.Collections.Generic;

namespace Bearchop.LOTW.Core.Models
{
    public partial class Week
    {
        public Week()
        {
            this.Games = new List<Game>();
            this.Picks = new List<Pick>();
            this.Schedules = new List<Schedule>();
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public System.DateTime BeginDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<Pick> Picks { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
