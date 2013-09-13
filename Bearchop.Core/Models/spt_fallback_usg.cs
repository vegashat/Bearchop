using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class spt_fallback_usg
    {
        public string xserver_name { get; set; }
        public System.DateTime xdttm_ins { get; set; }
        public System.DateTime xdttm_last_ins_upd { get; set; }
        public Nullable<int> xfallback_vstart { get; set; }
        public short dbid { get; set; }
        public int segmap { get; set; }
        public int lstart { get; set; }
        public int sizepg { get; set; }
        public int vstart { get; set; }
    }
}
