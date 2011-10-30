using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contests.LOTW.Core.Model
{
    public class Schedule
    {
        public int Id { get; set; }
        public int WeekId { get; set; }
        public int HomeId { get; set; }
        public int AwayId { get; set; }
        public DateTime Date { get; set; }
        public Week Week { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
    }
}
