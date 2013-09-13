using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class vw_JPOINTS
    {
        public int UserID { get; set; }
        public string ContestID { get; set; }
        public short ContestYear { get; set; }
        public short Place { get; set; }
        public string Points { get; set; }
        public Nullable<int> UserCount { get; set; }
        public int Champion { get; set; }
        public int MVP { get; set; }
        public int AllStar { get; set; }
        public int Star { get; set; }
        public int JPoints { get; set; }
    }
}
