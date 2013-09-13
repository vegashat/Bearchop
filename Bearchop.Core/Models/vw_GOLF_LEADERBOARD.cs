using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class vw_GOLF_LEADERBOARD
    {
        public short GolferID { get; set; }
        public string Golfer { get; set; }
        public string Country { get; set; }
        public Nullable<int> Golfer_Value { get; set; }
        public Nullable<int> Masters { get; set; }
        public Nullable<int> USOpen { get; set; }
        public Nullable<int> British { get; set; }
        public Nullable<int> PGA { get; set; }
        public Nullable<short> Golfer_Points { get; set; }
    }
}
