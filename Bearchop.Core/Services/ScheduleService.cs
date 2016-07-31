using Bearchop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bearchop.Core.Services
{
    public class ScheduleService
    {
        JeauxDBContext _jeauxContext = new JeauxDBContext();

        public IEnumerable<UserTeamStatus> GetUserSchedule(int userId, int week = 1)
        {
            List<UserTeamStatus> teams = new List<UserTeamStatus>();

            //get the schedules
            var schedules = _jeauxContext.UserWeeklySchedule.Where(us => us.UserId == userId);

            Dictionary<int, IQueryable<UserWeeklySchedule>> byeWeekSchedules = new Dictionary<int, IQueryable<UserWeeklySchedule>>();

            //Load the bye weeks
            byeWeekSchedules.Add(1, schedules.Where(s => s.Week1Opponent == string.Empty));
            byeWeekSchedules.Add(2, schedules.Where(s => s.Week2Opponent == string.Empty));
            byeWeekSchedules.Add(3, schedules.Where(s => s.Week3Opponent == string.Empty));
            byeWeekSchedules.Add(4, schedules.Where(s => s.Week4Opponent == string.Empty));
            byeWeekSchedules.Add(5, schedules.Where(s => s.Week5Opponent == string.Empty));
            byeWeekSchedules.Add(6, schedules.Where(s => s.Week6Opponent == string.Empty));
            byeWeekSchedules.Add(7, schedules.Where(s => s.Week7Opponent == string.Empty));
            byeWeekSchedules.Add(8, schedules.Where(s => s.Week8Opponent == string.Empty));
            byeWeekSchedules.Add(9, schedules.Where(s => s.Week9Opponent == string.Empty));
            byeWeekSchedules.Add(10, schedules.Where(s => s.Week10Opponent == string.Empty));
            byeWeekSchedules.Add(11, schedules.Where(s => s.Week11Opponent == string.Empty));
            byeWeekSchedules.Add(12, schedules.Where(s => s.Week12Opponent == string.Empty));
            byeWeekSchedules.Add(13, schedules.Where(s => s.Week13Opponent == string.Empty));
            byeWeekSchedules.Add(14, schedules.Where(s => s.Week14Opponent == string.Empty));
            byeWeekSchedules.Add(15, schedules.Where(s => s.Week15Opponent == string.Empty));


            foreach (var schedule in schedules)
            {
                UserTeamStatus team = new UserTeamStatus();
                team.Schedule = schedule;
                team.TeamInfo = _jeauxContext.COLFOOT_TEAM.First(t => t.TeamID == schedule.TeamId);
               
                team.SharedByWeekTeamIds = new Dictionary<int,int>();
                team.ByeWeeks = new List<int>();

                foreach(var byeWeek in byeWeekSchedules.Keys.Where(k => k > week))
                {
                    var byeWeekSchedule = byeWeekSchedules[byeWeek];

                    if (byeWeekSchedule.Count(s => s.TeamId == schedule.TeamId) == 1)
                    {
                        team.ByeWeeks.Add(byeWeek);
                    }
                    
                    if (byeWeek < 14 && byeWeekSchedule.Count() > 1 && byeWeekSchedule.Count(s => s.TeamId == schedule.TeamId) == 1) 
                    {
                        AddByeWeekTeams(schedule, team, byeWeekSchedule, byeWeek);
                    }                    
                }

                team.SharesByeWeek = team.SharedByWeekTeamIds.Count > 0;

                teams.Add(team);

            }

            return teams;

        }

        private static void AddByeWeekTeams(UserWeeklySchedule schedule, UserTeamStatus team, IQueryable<UserWeeklySchedule> week, int weekNumber)
        {
            foreach (var byeWeekTeam in week.Where(w => w.TeamId != schedule.TeamId))
            {
                if (!team.SharedByWeekTeamIds.Contains(new KeyValuePair<int,int>(weekNumber, byeWeekTeam.TeamId)))
                {
                    //team.SharedByWeekTeamIds.Add(weekNumber, byeWeekTeam.TeamId);
                }
            }
        }

        public IEnumerable<TeamWeeklySchedule> GetAvailableTeams(int userId, int teamId)
        {
            var team = _jeauxContext.COLFOOT_TEAM.First(t => t.TeamID == teamId);

            var availableTeams = from t in _jeauxContext.TeamWeeklySchedule
                                 join c in _jeauxContext.COLFOOT_TEAM on t.TeamId equals c.TeamID
                                 where t.TeamId != teamId
                                 && c.Price <= team.Price
                                 select t;

            return availableTeams;
        }

        public int AddTeam(string teamName)
        {
            var existingTeam = _jeauxContext.NCAAFootballTeams.FirstOrDefault(t => t.Name == teamName);

            if (existingTeam != null)
            {
                if (_jeauxContext.NCAAFootballTeams.Count(t => t.TeamId == existingTeam.TeamId) == 0)
                {

                    var team = new NCAAFootballTeam() { TeamId = existingTeam.TeamId, Name = teamName, IsSelectable = true , JeauxTeamId = existingTeam.TeamId};
                    _jeauxContext.NCAAFootballTeams.Add(team);
                    _jeauxContext.SaveChanges();

                    return team.TeamId;
                }

                return existingTeam.TeamId;
            }
            else
            {
                var alreadyInserted = _jeauxContext.NCAAFootballTeams.FirstOrDefault(t => t.Name == teamName);

                if (alreadyInserted == null)
                {
                    var maxTeamId = from t in _jeauxContext.NCAAFootballTeams
                                    orderby t.TeamId descending
                                    select t.TeamId;

                    var maxCOLFOOTTeamId = from t in _jeauxContext.COLFOOT_TEAM
                                           orderby t.TeamID descending
                                           select t.TeamID;

                    var maxId = maxTeamId.FirstOrDefault();

                    if (maxId == null || maxId < maxCOLFOOTTeamId.FirstOrDefault())
                    {
                        maxId = maxCOLFOOTTeamId.FirstOrDefault();
                    }

                    maxId++;

                    var team = new NCAAFootballTeam() { TeamId = maxId, Name = teamName, IsSelectable = false };
                    _jeauxContext.NCAAFootballTeams.Add(team);
                    _jeauxContext.SaveChanges();

                    return team.TeamId;

                }

                return alreadyInserted.TeamId;
            }
        }

        public void AddSchedule(int homeTeamId, int awayTeamId, DateTime gameDate, string gameCode)
        {
            NCAAFootballSchedule schedule = new NCAAFootballSchedule();

            schedule.HomeTeamId = homeTeamId;
            schedule.AwayTeamId = awayTeamId;
            schedule.Date = gameDate;
            schedule.GameCode = gameCode;
            var week = _jeauxContext.NCAAFootballWeeks.First(w => w.BeginDate <= gameDate && w.EndDate >= gameDate);

            schedule.Week = week.Number;

            _jeauxContext.NCAAFootballSchedules.Add(schedule);
            _jeauxContext.SaveChanges();
        }

        public IEnumerable<NCAAFootballSchedule> GetSchedules(bool onlySelectable, bool unfinalizedOnly = true, int week = 0)
        {
            if(week == 0)
            {
                var today = DateTime.Today;
                week = _jeauxContext.NCAAFootballWeeks.FirstOrDefault(w => w.BeginDate <= today && w.EndDate >= today).Number;
            }

            if(onlySelectable)
            {
                var selectableTeams = (from j in _jeauxContext.NCAAFootballTeams.Where(t=>t.IsSelectable == true)
                                      select (int)j.TeamId).ToList();
                return _jeauxContext.NCAAFootballSchedules.Where(s => s.Week.Value == week && ((unfinalizedOnly == true && s.IsFinal == false) || unfinalizedOnly == false) && (selectableTeams.Contains(s.HomeTeamId) || selectableTeams.Contains(s.AwayTeamId))).ToList();
            }
            else
            {
                return _jeauxContext.NCAAFootballSchedules.Where(s => s.Week.Value == week && ((unfinalizedOnly == true && s.IsFinal == false) || unfinalizedOnly == false)).ToList();
            }
        }

        public void  FinalizeGame(string gameCode)
        {
            var schedule = _jeauxContext.NCAAFootballSchedules.First(s => s.GameCode == gameCode);
            schedule.IsFinal = true;
            _jeauxContext.SaveChanges();
        }
    }
}
