using Bearchop.LOTW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bearchop.LOTW.Core.Service
{
    public class TeamService
    {
        LOTWContext _context = null;

        public TeamService()
        {
            _context = new LOTWContext();
        }

        public int GetTeamId(string teamName)
        {
            return _context.Teams.FirstOrDefault(t => t.Name == teamName).Id;
        }


        public Team GetTeam(string nickname)
        {
            var team = _context.Teams.FirstOrDefault(t => t.Nickname == nickname);

            if(team == null)
            {
                team = _context.Teams.First(t => t.Name.Contains(nickname));
                team.Nickname = nickname;
                _context.SaveChanges();
            }

            return team;
        }
    }
}
