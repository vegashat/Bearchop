using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class NAS_TEAM
    {
        public string Sport { get; set; }
        public string Team { get; set; }
        public string Year { get; set; }
        public string Division { get; set; }
        public Nullable<byte> Wins { get; set; }
        public Nullable<byte> Playoff { get; set; }
        public Nullable<byte> League { get; set; }
        public Nullable<byte> Finals { get; set; }
        public Nullable<byte> Champion { get; set; }
        public Nullable<decimal> Points { get; set; }
        public Nullable<System.DateTime> Update_DtTm { get; set; }
    }
}
