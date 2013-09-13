using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class BIG12_PICKS
    {
        public int UserID { get; set; }
        public byte Week { get; set; }
        public string Team { get; set; }
        public string Opponent { get; set; }
        public Nullable<byte> TeamGuess { get; set; }
        public Nullable<byte> OppGuess { get; set; }
        public string OrigGuess { get; set; }
        public Nullable<System.DateTime> TradeDate { get; set; }
    }
}
