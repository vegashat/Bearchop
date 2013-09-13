using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class JEVENT
    {
        public int EventID { get; set; }
        public byte EventMonth { get; set; }
        public byte EventDay { get; set; }
        public string EventType { get; set; }
        public string Event { get; set; }
    }
}
