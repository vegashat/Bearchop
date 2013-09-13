using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class NCAA_PICK
    {
        public int UserID { get; set; }
        public string GameID { get; set; }
        public string TeamPick { get; set; }
        public Nullable<byte> Points { get; set; }
        public virtual NCAA_GAME NCAA_GAME { get; set; }
        public virtual NCAA_PLAYER NCAA_PLAYER { get; set; }
        public virtual NCAA_TEAM NCAA_TEAM { get; set; }
    }
}
