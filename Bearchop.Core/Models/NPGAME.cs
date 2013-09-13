using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class NPGAME
    {
        public int GameId { get; set; }
        public string SeriesId { get; set; }
        public Nullable<int> Game { get; set; }
        public Nullable<System.DateTime> GameDateTime { get; set; }
        public Nullable<int> Team1Score { get; set; }
        public Nullable<int> Team2Score { get; set; }
    }
}
