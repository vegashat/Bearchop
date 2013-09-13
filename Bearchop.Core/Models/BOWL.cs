using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class BOWL
    {
        public BOWL()
        {
            this.BOWL_PICKS = new List<BOWL_PICKS>();
        }

        public byte BowlID { get; set; }
        public Nullable<System.DateTime> BowlDate { get; set; }
        public string BowlName { get; set; }
        public string Location { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public string Winner { get; set; }
        public string Pick { get; set; }
        public Nullable<byte> Rank { get; set; }
        public virtual ICollection<BOWL_PICKS> BOWL_PICKS { get; set; }
    }
}
