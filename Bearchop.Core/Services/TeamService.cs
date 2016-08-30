using Bearchop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bearchop.Core.Services
{
    public class TeamService
    {
        JeauxDBContext _jeauxContext = null;

        public TeamService()
        {
            _jeauxContext = new JeauxDBContext();
        }

        public  COLFOOT_TEAM GetTeam(short teamId)
        {
            return _jeauxContext.COLFOOT_TEAM.FirstOrDefault(t => t.TeamID == teamId);
        }

        public NCAAFootballTeam GetNCAAFootballTeam(int teamId)
        {
            return _jeauxContext.NCAAFootballTeams.FirstOrDefault(t => t.TeamId == teamId);
        }
    }
}
