using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class NCAA_GAME
    {
        public NCAA_GAME()
        {
            this.NCAA_PICK = new List<NCAA_PICK>();
        }

        public string GameID { get; set; }
        public Nullable<byte> Round { get; set; }
        public string Location { get; set; }
        public Nullable<System.DateTime> GameDate { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public Nullable<byte> Team1Score { get; set; }
        public Nullable<byte> Team2Score { get; set; }
        public string Winner { get; set; }
        public Nullable<byte> Points { get; set; }
        public string NextGame { get; set; }
        public string RegionID { get; set; }
        public virtual NCAA_TEAM NCAA_TEAM { get; set; }
        public virtual NCAA_TEAM NCAA_TEAM1 { get; set; }
        public virtual ICollection<NCAA_PICK> NCAA_PICK { get; set; }
    }
}
