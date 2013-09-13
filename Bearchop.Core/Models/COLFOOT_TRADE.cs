using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class COLFOOT_TRADE
    {
        public int UserID { get; set; }
        public byte Week { get; set; }
        public int Team1 { get; set; }
        public int Team2 { get; set; }
        public string Team1_Name { get; set; }
        public string Team2_Name { get; set; }
    }
}
