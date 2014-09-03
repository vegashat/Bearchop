using System;
using System.Collections.Generic;

namespace Bearchop.LOTW.Core.Models
{
    public partial class Pick
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WeekId { get; set; }
        public int GameId { get; set; }
        public string Team { get; set; }
        public int TypeValue { get; set; }
        public int OverUnderValue { get; set; }
        public decimal Points { get; set; }
        public bool HasOverUnder { get; set; }
        public virtual Game Game { get; set; }
        public virtual LOTWUser LOTWUser { get; set; }
        public virtual Week Week { get; set; }
    }
}
