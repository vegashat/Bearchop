using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class NCAAFootballSchedule
    {
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }

        public string GameCode { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<int> Week { get; set; }
        public bool IsFinal { get; set; }
    }
}
