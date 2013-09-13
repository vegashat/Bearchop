using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class NPStanding
    {
        public Nullable<long> Place { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public Nullable<int> Points { get; set; }
        public Nullable<int> PotentialPoints { get; set; }
    }
}
