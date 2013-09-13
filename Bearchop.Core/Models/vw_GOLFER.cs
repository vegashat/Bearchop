using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class vw_GOLFER
    {
        public short GolferID { get; set; }
        public string Golfer { get; set; }
        public string Country { get; set; }
        public byte Rank { get; set; }
        public Nullable<int> Golfer_Value { get; set; }
        public Nullable<short> Golfer_Points { get; set; }
        public string Major_Name { get; set; }
        public string Course { get; set; }
        public Nullable<short> Score { get; set; }
        public Nullable<byte> ParPts { get; set; }
        public string Bonus { get; set; }
        public Nullable<byte> BonusPts { get; set; }
        public Nullable<byte> TierPts { get; set; }
        public Nullable<byte> TotalPts { get; set; }
    }
}
