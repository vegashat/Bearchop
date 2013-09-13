using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class NCAA_TEAM
    {
        public NCAA_TEAM()
        {
            this.NCAA_GAME = new List<NCAA_GAME>();
            this.NCAA_GAME1 = new List<NCAA_GAME>();
            this.NCAA_PICK = new List<NCAA_PICK>();
        }

        public string TeamID { get; set; }
        public string TeamName { get; set; }
        public Nullable<byte> Seed { get; set; }
        public string RegionID { get; set; }
        public virtual ICollection<NCAA_GAME> NCAA_GAME { get; set; }
        public virtual ICollection<NCAA_GAME> NCAA_GAME1 { get; set; }
        public virtual ICollection<NCAA_PICK> NCAA_PICK { get; set; }
    }
}
