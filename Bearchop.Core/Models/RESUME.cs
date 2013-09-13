using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class RESUME
    {
        public int UserID { get; set; }
        public string ContestID { get; set; }
        public short ContestYear { get; set; }
        public short Place { get; set; }
        public string Points { get; set; }
        public virtual CONTEST CONTEST { get; set; }
        public virtual JUSER JUSER { get; set; }
    }
}
