using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class BIG12
    {
        public int UserID { get; set; }
        public byte Week { get; set; }
        public string UserName { get; set; }
        public Nullable<byte> Wins { get; set; }
        public Nullable<byte> Losses { get; set; }
        public Nullable<short> Diff { get; set; }
    }
}
