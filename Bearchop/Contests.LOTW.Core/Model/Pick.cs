using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contests.LOTW.Core.Model
{    
    public enum PickType
    {        
        StraightUp = 0,
        AgainstTheSpread = 1,
        ATSOverUnder = 2
    }

    public class Pick
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WeekId { get; set; }
        public int GameId { get; set; }
        public string Team { get; set; }
        public int TypeValue { get; set; }

        [NotMapped]
        public PickType Type
        {
            get { return (PickType) TypeValue; }
            set { TypeValue = (int)value; }
        }
        public int OverUnderValue { get; set; }

        [NotMapped]
        public OverUnder OverUnder  
        {
            get { return (OverUnder) OverUnderValue; }
            set { OverUnderValue = (int) value; }
        }
        public decimal Points { get; set; }
        public Week Week { get; set; }
        public LOTWUser User { get; set; }
    }
}
