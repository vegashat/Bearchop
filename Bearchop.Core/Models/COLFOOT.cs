using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class COLFOOT
    {
        public int UserID { get; set; }
        public short TeamID { get; set; }
        public byte Week { get; set; }
        public string UserName { get; set; }
        public Nullable<short> Points { get; set; }
        public virtual COLFOOT_TEAM COLFOOT_TEAM { get; set; }
    }
}
