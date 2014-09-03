using System;
using System.Collections.Generic;

namespace Bearchop.LOTW.Core.Models
{
    public partial class Schedule
    {
        public int Id { get; set; }
        public int WeekId { get; set; }
        public int HomeId { get; set; }
        public int AwayId { get; set; }
        public System.DateTime Date { get; set; }
        public decimal HomeTeamSpread { get; set; }
        public decimal OverUnder { get; set; }        
        public string GameCode { get; set; }        
        public virtual Team AwayTeam { get; set; }
        public virtual Team HomeTeam { get; set; }
        public virtual Week Week { get; set; }
    }
}
