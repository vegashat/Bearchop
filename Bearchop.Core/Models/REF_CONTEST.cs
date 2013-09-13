using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class REF_CONTEST
    {
        public REF_CONTEST()
        {
            this.CONTESTs = new List<CONTEST>();
        }

        public string ContestID { get; set; }
        public string ContestName { get; set; }
        public Nullable<byte> Sequence { get; set; }
        public string ContestURL { get; set; }
        public virtual ICollection<CONTEST> CONTESTs { get; set; }
    }
}
