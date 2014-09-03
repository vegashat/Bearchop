using System;
using System.Collections.Generic;

namespace Bearchop.LOTW.Core.Models
{
    public partial class LOTWUser
    {
        public LOTWUser()
        {
            this.Picks = new List<Pick>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public virtual ICollection<Pick> Picks { get; set; }
    }
}
