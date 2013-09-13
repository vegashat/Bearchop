using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class BIG12_SCHEDULE
    {
        public byte Week { get; set; }
        public string Team { get; set; }
        public string Opponent { get; set; }
        public Nullable<byte> TeamScore { get; set; }
        public Nullable<byte> OppScore { get; set; }
    }
}
