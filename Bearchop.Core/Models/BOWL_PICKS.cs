using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class BOWL_PICKS
    {
        public byte BowlID { get; set; }
        public int UserID { get; set; }
        public Nullable<byte> Rank { get; set; }
        public string Winner { get; set; }
        public Nullable<short> Points { get; set; }
        public string BowlName { get; set; }
        public virtual BOWL BOWL { get; set; }
    }
}
