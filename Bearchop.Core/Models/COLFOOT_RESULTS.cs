using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class COLFOOT_RESULTS
    {
        public short TeamID { get; set; }
        public byte Week { get; set; }
        public string Name { get; set; }
        public Nullable<short> WinLoss { get; set; }
        public Nullable<short> Score { get; set; }
        public Nullable<short> OPass { get; set; }
        public Nullable<short> ORush { get; set; }
        public Nullable<short> TA { get; set; }
        public Nullable<short> DPass { get; set; }
        public Nullable<short> DRush { get; set; }
        public Nullable<short> TF { get; set; }
        public Nullable<short> Points { get; set; }
        public virtual COLFOOT_TEAM COLFOOT_TEAM { get; set; }
    }
}
