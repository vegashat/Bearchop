using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class NCAAFootballTeam
    {
        public short TeamId { get; set; }
        public string Name { get; set; }
        public Nullable<bool> IsSelectable { get; set; }
        public int JeauxTeamId { get; set; }
    }
}
