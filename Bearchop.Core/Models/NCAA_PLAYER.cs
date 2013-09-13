using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class NCAA_PLAYER
    {
        public NCAA_PLAYER()
        {
            this.NCAA_PICK = new List<NCAA_PICK>();
        }

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Pod { get; set; }
        public Nullable<short> Points { get; set; }
        public virtual ICollection<NCAA_PICK> NCAA_PICK { get; set; }
        public virtual NCAA_POD NCAA_POD { get; set; }
    }
}
