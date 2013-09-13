using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class NBA_GAME
    {
        public System.DateTime GameDate { get; set; }
        public Nullable<System.DateTime> GameDateTime { get; set; }
        public string Team { get; set; }
        public Nullable<bool> Premier { get; set; }
        public Nullable<byte> Tickets { get; set; }
    }
}
