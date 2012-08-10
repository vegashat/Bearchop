using System;
using System.Collections.Generic;

namespace NCAAF.Model.Models
{
    public class Schedule
    {
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<int> Week { get; set; }
        public virtual Team Team { get; set; }
        public virtual Week Week1 { get; set; }
        public virtual Team Team1 { get; set; }
    }
}
