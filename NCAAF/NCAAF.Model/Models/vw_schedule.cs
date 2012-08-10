using System;
using System.Collections.Generic;

namespace NCAAF.Model.Models
{
    public class vw_schedule
    {
        public System.DateTime Date { get; set; }
        public int HomeTeamId { get; set; }
        public string HomeName { get; set; }
        public int AwayTeamId { get; set; }
        public string AwayName { get; set; }
        public Nullable<int> Week { get; set; }
    }
}
