using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class NCAA_POD
    {
        public NCAA_POD()
        {
            this.NCAA_PLAYER = new List<NCAA_PLAYER>();
        }

        public string Pod { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Color { get; set; }
        public virtual ICollection<NCAA_PLAYER> NCAA_PLAYER { get; set; }
    }
}
