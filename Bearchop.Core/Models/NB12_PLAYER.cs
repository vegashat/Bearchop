using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class NB12_PLAYER
    {
        public byte Draft_Order { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public Nullable<byte> Wins { get; set; }
        public Nullable<byte> Losses { get; set; }
        public Nullable<byte> Ties { get; set; }
        public Nullable<int> Points { get; set; }
    }
}
