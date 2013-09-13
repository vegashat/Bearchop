using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bearchop.Core.Models
{
    public class UserTeamStatus
    {
        public UserWeeklySchedule Schedule { get; set; }
        public COLFOOT_TEAM TeamInfo { get; set; }
        public IList<int> ByeWeeks { get; set; }
        public bool SharesByeWeek { get; set; }

        public Dictionary<int,int> SharedByWeekTeamIds { get; set; }

        

    }
}
