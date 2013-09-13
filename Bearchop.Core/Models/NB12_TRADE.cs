using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class NB12_TRADE
    {
        public int TradeNumber { get; set; }
        public string TradeType { get; set; }
        public Nullable<System.DateTime> TradeDate { get; set; }
        public string FromUser { get; set; }
        public string ToUser { get; set; }
        public string FromPlayers { get; set; }
        public string ToPlayers { get; set; }
        public Nullable<bool> Approved { get; set; }
    }
}
