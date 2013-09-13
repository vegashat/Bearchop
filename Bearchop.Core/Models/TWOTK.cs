using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class TWOTK
    {
        public int UserID { get; set; }
        public System.DateTime PostDate { get; set; }
        public Nullable<short> Pushups { get; set; }
        public Nullable<short> Situps { get; set; }
        public Nullable<int> PushupsYTD { get; set; }
        public Nullable<int> SitupsYTD { get; set; }
        public Nullable<decimal> PushupsAvg { get; set; }
        public Nullable<decimal> SitupsAvg { get; set; }
        public Nullable<decimal> PushupsPace { get; set; }
        public Nullable<decimal> SitupsPace { get; set; }
        public Nullable<decimal> DailyAvg { get; set; }
        public Nullable<int> PaceYTD { get; set; }
    }
}
