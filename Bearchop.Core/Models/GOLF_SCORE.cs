using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class GOLF_SCORE
    {
        public short GolferID { get; set; }
        public string Major { get; set; }
        public short Score { get; set; }
        public byte ParPts { get; set; }
        public byte BonusPts { get; set; }
        public byte TierPts { get; set; }
        public byte TotalPts { get; set; }
        public virtual GOLF_MAJOR GOLF_MAJOR { get; set; }
        public virtual GOLFER GOLFER { get; set; }
    }
}
