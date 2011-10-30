using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contests.LOTW.Core.Model;
using Contests.LOTW.Core.Repository;

namespace Contests.LOTW.Core.Service
{
    public class PickService
    {
        LOTWContext _context = new LOTWContext();

        public IQueryable<Pick> GetUserPicks(int userId)
        {
                return from p in _context.Picks
                       where p.UserId == userId
                       orderby p.WeekId
                       select p;
        }

        public IQueryable<Pick> GetUserPicksForWeek(int userId, int week)
        {
                return from p in _context.Picks
                       join w in _context.Weeks on p.WeekId equals w.Id into pw                                                                     
                       from x in pw
                       where x.Number == week
                       && p.UserId == userId
                       select p;
        }

        public IQueryable<Pick> GetWeekPicks(int week)
        {
                return from p in _context.Picks
                       join w in _context.Weeks on p.WeekId equals w.Id into pw                       
                       from x in pw
                       where x.Number == week                       
                       select p;
        }

        public void SavePick(Pick pick)
        {
            //get the week and make sure this is being saved before the game
            var game = _context.Games.FirstOrDefault(g => g.Id == pick.GameId);

            //Continue on
            if (game.Date > DateTime.Now)
            {
                //if (pick.Id > 0)
                //{
                //    _context.Picks.Attach(pick);
                //    _context.Entry(pick).State = System.Data.EntityState.Modified;
                //}
                //else
                {
                    _context.Picks.Add(pick);
                }

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Game has already started");
            }
        }

        public void RemovePicks(int userId, int week)
        {
            var picks = _context.Picks.Where(p => p.UserId == userId && p.Week.Number == week);

            foreach (var pick in picks)
            {
                _context.Picks.Remove(pick);
            }

            _context.SaveChanges();
        }
    }
}
