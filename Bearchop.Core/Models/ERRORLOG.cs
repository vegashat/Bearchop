using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class ERRORLOG
    {
        public System.DateTime LogDate { get; set; }
        public string Exception { get; set; }
        public string StackTrace { get; set; }
    }
}
