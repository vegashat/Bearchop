using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class vw_GOLF_LINEUP
    {
        public string UserName { get; set; }
        public short GolferID { get; set; }
        public string Golfer { get; set; }
        public string Country { get; set; }
        public byte Rank { get; set; }
        public Nullable<int> Lineup_Value { get; set; }
        public Nullable<int> Golfer_Value { get; set; }
        public string Value_Differs { get; set; }
        public int Renegotiate_Flag { get; set; }
        public Nullable<short> Golfer_Points { get; set; }
        public int Selected_Golfer { get; set; }
        public int UserID { get; set; }
        public int Current_Flag { get; set; }
        public byte TotalPts { get; set; }
    }
}
