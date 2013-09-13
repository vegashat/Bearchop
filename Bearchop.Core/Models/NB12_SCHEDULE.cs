using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class NB12_SCHEDULE
    {
        public byte Week { get; set; }
        public byte Game { get; set; }
        public Nullable<System.DateTime> WeekDate { get; set; }
        public Nullable<byte> D01 { get; set; }
        public Nullable<byte> D02 { get; set; }
        public string D01_User { get; set; }
        public string D02_User { get; set; }
        public Nullable<byte> D01_Points { get; set; }
        public Nullable<byte> D02_Points { get; set; }
    }
}
