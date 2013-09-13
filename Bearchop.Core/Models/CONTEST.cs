using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class CONTEST
    {
        public CONTEST()
        {
            this.RESUMEs = new List<RESUME>();
        }

        public string ContestID { get; set; }
        public short ContestYear { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<System.DateTime> RegisterDate { get; set; }
        public string Winner { get; set; }
        public string Picture { get; set; }
        public string Caption { get; set; }
        public string Details { get; set; }
        public Nullable<int> UserCount { get; set; }
        public Nullable<System.DateTime> MidStart { get; set; }
        public Nullable<System.DateTime> MidEnd { get; set; }
        public virtual ICollection<RESUME> RESUMEs { get; set; }
        public virtual REF_CONTEST REF_CONTEST { get; set; }
    }
}
