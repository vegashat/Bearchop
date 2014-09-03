using System;
using System.Collections.Generic;

namespace Bearchop.LOTW.Core.Models
{
    public partial class Team
    {
        public Team()
        {
            this.Schedules = new List<Schedule>();
            this.Schedules1 = new List<Schedule>();
        }

        public int Id { get; set; }
        public int DivisionId { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<Schedule> Schedules1 { get; set; }
    }
}
