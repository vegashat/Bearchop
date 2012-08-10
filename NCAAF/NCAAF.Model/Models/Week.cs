using System;
using System.Collections.Generic;

namespace NCAAF.Model.Models
{
    public class Week
    {
        public Week()
        {
            this.Schedules = new List<Schedule>();
        }

        public int Number { get; set; }
        public System.DateTime BeginDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
