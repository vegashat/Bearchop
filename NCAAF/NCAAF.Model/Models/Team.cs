using System;
using System.Collections.Generic;

namespace NCAAF.Model.Models
{
    public class Team
    {
        public Team()
        {
            this.Schedules = new List<Schedule>();
            this.Schedules1 = new List<Schedule>();
        }

        public int TeamId { get; set; }
        public string Name { get; set; }
        public Nullable<bool> IsSelectable { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<Schedule> Schedules1 { get; set; }
    }
}
