using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class NB12_PICK
    {
        public int Pick { get; set; }
        public string UserName { get; set; }
        public string Player { get; set; }
        public string Pos { get; set; }
        public string Team { get; set; }
        public Nullable<int> Points { get; set; }
        public string Acquired { get; set; }
        public Nullable<bool> ActiveFlag { get; set; }
        public Nullable<byte> PriorWeek { get; set; }
        public Nullable<byte> PriorGame { get; set; }
        public Nullable<byte> PriorPoints { get; set; }
    }
}
