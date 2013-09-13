using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class GOLFER
    {
        public GOLFER()
        {
            this.GOLF_SCORE = new List<GOLF_SCORE>();
        }

        public short GolferID { get; set; }
        public string Golfer1 { get; set; }
        public string Country { get; set; }
        public byte Rank { get; set; }
        public Nullable<int> Golfer_Value { get; set; }
        public Nullable<short> Golfer_Points { get; set; }
        public virtual ICollection<GOLF_SCORE> GOLF_SCORE { get; set; }
    }
}
