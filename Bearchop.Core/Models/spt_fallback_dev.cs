using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class spt_fallback_dev
    {
        public string xserver_name { get; set; }
        public System.DateTime xdttm_ins { get; set; }
        public System.DateTime xdttm_last_ins_upd { get; set; }
        public Nullable<int> xfallback_low { get; set; }
        public string xfallback_drive { get; set; }
        public int low { get; set; }
        public int high { get; set; }
        public short status { get; set; }
        public string name { get; set; }
        public string phyname { get; set; }
    }
}
