using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class GOLF_LINEUP
    {
        public int UserID { get; set; }
        public short GolferID { get; set; }
        public string Major { get; set; }
        public Nullable<byte> Active_Flag { get; set; }
        public Nullable<int> Lineup_Value { get; set; }
        public Nullable<short> User_Points { get; set; }
    }
}
