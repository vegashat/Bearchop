using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class vw_NBA_CALENDAR
    {
        public System.DateTime GameDate { get; set; }
        public string GameTime { get; set; }
        public string Team { get; set; }
        public Nullable<bool> Premier { get; set; }
        public Nullable<byte> Tickets { get; set; }
        public string Owner { get; set; }
        public Nullable<int> Picks { get; set; }
        public Nullable<byte> Pick { get; set; }
        public Nullable<byte> Ball { get; set; }
    }
}
