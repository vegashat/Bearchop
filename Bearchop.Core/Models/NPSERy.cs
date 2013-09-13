using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class NPSERy
    {
        public string SeriesID { get; set; }
        public int RoundId { get; set; }
        public string Division { get; set; }
        public string Team1 { get; set; }
        public Nullable<short> Team1Wins { get; set; }
        public string Team2 { get; set; }
        public Nullable<short> Team2Wins { get; set; }
        public Nullable<bool> SeriesWon { get; set; }
    }
}
