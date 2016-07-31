using Bearchop.Core.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bearchop.Core.Services
{
    public class NCAAFScoringService
    {

        JeauxDBContext _jeauxContext = null;
        public NCAAFScoringService()
        {
            _jeauxContext = new JeauxDBContext();
        }

        public COLFOOT_RESULTS GetJeauxResults(int teamdId, int week)
        {
            var result = _jeauxContext.COLFOOT_RESULTS.AsNoTracking().FirstOrDefault(c => c.TeamID == teamdId && c.Week == week);

            if(result == null)
            {
                result = new COLFOOT_RESULTS() { TeamID = (short)teamdId };
            }

            return result;
        }

        public void UpdateResult(COLFOOT_RESULTS result)
        {
            try
                {
                result.COLFOOT_TEAM = _jeauxContext.COLFOOT_TEAM.Find(result.TeamID);
                result.Name = result.COLFOOT_TEAM.Name;
                if (_jeauxContext.COLFOOT_RESULTS.Any(c => c.TeamID == result.TeamID && c.Week == result.Week))
                {
                    _jeauxContext.Entry<COLFOOT_RESULTS>(result).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    _jeauxContext.COLFOOT_RESULTS.Add(result);
                }
            
                _jeauxContext.SaveChanges();

                if (ConfigurationManager.AppSettings["UpdateStandings"].ToString().ToUpper() == "TRUE")
                {
                    UpdateTeamTotals(result.Week, result.TeamID);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());  
                throw;
            }
        }

        public void UpdateTeamTotals(byte week, short teamId)
        {
            _jeauxContext.Database.ExecuteSqlCommand("usp_COLFOOT_UPDATE_TEAM", week, teamId);
        }
    }
}
