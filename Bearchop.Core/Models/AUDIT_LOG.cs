using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class AUDIT_LOG
    {
        public long Audit_ID { get; set; }
        public System.DateTime Audit_Dttm { get; set; }
        public string Description { get; set; }
    }
}
