using System;
using System.Collections.Generic;

namespace Bearchop.LOTW.Core.Models
{
    public partial class vw_team_schedule
    {
        public int Week { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public System.DateTime Date { get; set; }
        public string GameCode { get; set; }
        public int Homeid { get; set; }
        public int AwayId { get; set; }
    }
}
