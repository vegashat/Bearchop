using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class NBA_PICK
    {
        public byte Ball { get; set; }
        public string Owner { get; set; }
        public Nullable<System.DateTime> Game { get; set; }
        public Nullable<byte> Pick { get; set; }
    }
}
