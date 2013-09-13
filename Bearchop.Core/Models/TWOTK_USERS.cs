using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class TWOTK_USERS
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<int> Pushups { get; set; }
        public Nullable<System.DateTime> PushupsCompleted { get; set; }
        public Nullable<int> Situps { get; set; }
        public Nullable<System.DateTime> SitupsCompleted { get; set; }
        public string ShirtSize { get; set; }
    }
}
