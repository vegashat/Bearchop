using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class GOLF_MAJOR
    {
        public GOLF_MAJOR()
        {
            this.GOLF_SCORE = new List<GOLF_SCORE>();
        }

        public string Major { get; set; }
        public string Course { get; set; }
        public string Location { get; set; }
        public Nullable<System.DateTime> Register_Date { get; set; }
        public Nullable<System.DateTime> Start_Date { get; set; }
        public Nullable<System.DateTime> End_Date { get; set; }
        public virtual ICollection<GOLF_SCORE> GOLF_SCORE { get; set; }
    }
}
