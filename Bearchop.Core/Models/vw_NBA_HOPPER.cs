using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class vw_NBA_HOPPER
    {
        public string Owner { get; set; }
        public Nullable<int> Picks_Made { get; set; }
        public Nullable<int> Picks_Remaining { get; set; }
        public Nullable<byte> Last_Pick { get; set; }
        public Nullable<System.DateTime> Last_Game { get; set; }
        public string Last_Team { get; set; }
        public string Team { get; set; }
    }
}
