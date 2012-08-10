using System;
using System.Collections.Generic;

namespace NCAAF.Model.Models
{
    public class vw_user_schedule
    {
        public int UserID { get; set; }
        public short TeamID { get; set; }
        public string name { get; set; }
        public string opponent { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<int> schedule_week { get; set; }
        public byte pick_week { get; set; }
        public byte CurrentWeek { get; set; }
    }
}
