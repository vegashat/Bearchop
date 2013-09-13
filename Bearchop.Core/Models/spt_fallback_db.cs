using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class spt_fallback_db
    {
        public string xserver_name { get; set; }
        public System.DateTime xdttm_ins { get; set; }
        public System.DateTime xdttm_last_ins_upd { get; set; }
        public Nullable<short> xfallback_dbid { get; set; }
        public string name { get; set; }
        public short dbid { get; set; }
        public short status { get; set; }
        public short version { get; set; }
    }
}
