using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class UserSchedule
    {
        public int UserID { get; set; }
        public short TeamID { get; set; }
        public string Name { get; set; }
        public string Opponent { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<int> ScheduleWeek { get; set; }
        public byte PickWeek { get; set; }
        public byte CurrentWeek { get; set; }
    }
}
