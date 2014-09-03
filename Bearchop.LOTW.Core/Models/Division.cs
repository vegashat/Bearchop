using System;
using System.Collections.Generic;

namespace Bearchop.LOTW.Core.Models
{
    public partial class Division
    {
        public int Id { get; set; }
        public int ConferenceId { get; set; }
        public string Name { get; set; }
    }
}
