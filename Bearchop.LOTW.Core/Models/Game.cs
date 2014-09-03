using System;
using System.Collections.Generic;

namespace Bearchop.LOTW.Core.Models
{
    public partial class Game
    {
        public Game()
        {
            this.Picks = new List<Pick>();
        }

        public int Id { get; set; }
        public int WeekId { get; set; }
        public System.DateTime Date { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public decimal HomeTeamSpread { get; set; }
        public decimal AwayTeamSpread { get; set; }
        public decimal OverUnder { get; set; }
        public decimal FinalScore { get; set; }
        public decimal HomeTeamScore { get; set; }
        public decimal AwayTeamScore { get; set; }
        public virtual Week Week { get; set; }
        public virtual ICollection<Pick> Picks { get; set; }
    }
}
