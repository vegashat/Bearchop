using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class HIT
    {
        public string Site { get; set; }
        public Nullable<int> HitCount { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
    }
}
