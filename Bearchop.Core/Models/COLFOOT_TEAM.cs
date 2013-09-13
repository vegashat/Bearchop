using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class COLFOOT_TEAM
    {
        public COLFOOT_TEAM()
        {
            //this.COLFeet = new List<COLFOOT>();
            //this.COLFOOT_RESULTS = new List<COLFOOT_RESULTS>();
        }

        public short TeamID { get; set; }
        public string Name { get; set; }
        public string Conference { get; set; }
        public Nullable<decimal> OPrice { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<short> Wins { get; set; }
        public Nullable<short> Losses { get; set; }
        public Nullable<short> Points { get; set; }
        public Nullable<short> OwnedBy { get; set; }
        public Nullable<decimal> RealValue { get; set; }
        public Nullable<bool> IsSelectable { get; set; }
        //public virtual ICollection<COLFOOT> COLFeet { get; set; }
        //public virtual ICollection<COLFOOT_RESULTS> COLFOOT_RESULTS { get; set; }
    }
}
