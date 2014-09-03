using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bearchop.LOTW.Core.Models;


namespace Bearchop.LOTW.Core.Service
{
    public class GameService
    {

        LOTWContext _context = new LOTWContext();

        public IQueryable<Game> GetNonFinalizedGames()
        {
            return from g in _context.Games
                   where g.Finalized == false
                   select g;
        }

        public IQueryable<Game> GetGames(int? week = null)
        {
            if (week.HasValue)
            {
                return from g in _context.Games.Include("Week")
                       where g.Week.Number == week
                       select g;
            }
            else
            {
                var games = from g in _context.Games.Include("Week")
                            where g.Week.BeginDate <= DateTime.Now && g.Week.EndDate >= DateTime.Now
                            select g;

                if (!games.Any())
                {
                    games = from g in _context.Games.Include("Week")
                            where g.Week.Number == 1
                            select g;
                }

                return games;
            }
        }

        public void SaveGame(Game game)
        {
            if (game.Id > 0)
            {
                //Update all of the scores
                if (game.Finalized)
                {
                    var picks = _context.Picks.Where(pick => pick.GameId == game.Id);

                    foreach (var pick in picks)
                    {
                        if (pick.Type == PickType.StraightUp)
                        {
                            pick.Points = (pick.Team == game.WinningTeam) ? 3 : 0;

                            if (pick.Team != game.Favorite && pick.Team == game.WinningTeam)
                            {
                                pick.Points += 2; //5 points for straight up underdog pick
                                pick.Points += Math.Abs(game.HomeTeamSpread);
                            }
                        }
                        else if (pick.Type == PickType.AgainstTheSpread)
                        {
                            pick.Points = (pick.Team == game.WinningTeamATS) ? 7 : 0;
                            //How to handle push?

                            if (game.WinningTeamATS == "PUSH")
                            {
                                pick.Points = 2;
                            }
                        }

                        if (pick.HasOverUnder)
                        {
                            if (pick.OverUnder == game.OverUnderResult && game.OverUnderResult != OverUnderEnum.Push)
                            {
                                pick.Points *= 2;
                            }
                            else
                            {
                                pick.Points = 0;
                            }
                        }

                    }

                    _context.SaveChanges();
                }

                _context.Games.Attach(game);
                _context.Entry(game).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                _context.Games.Add(game);
            }

            _context.SaveChanges();
        }

        public Game GetGame(int id)
        {
            return _context.Games.FirstOrDefault(game => game.Id == id);
        }

        public bool LoadGames(int week)
        {
            using (var context = new LOTWContext())
            {
                var possibleGames = (from t in context.Schedules.Include("HomeTeam").Include("AwayTeam")
                                     where t.Week.Number == week
                                     select t).ToList();

                var count = possibleGames.Count();

                var random = new RandomOrg.Random("vegashat@gmail.com", 60);

                List<int> selections = random.GetNumbers(0, count - 1, 5);
                
                var weekInfo = context.Weeks.FirstOrDefault(w => w.Number == week);
                                
                foreach (int selection in selections)
                {
                    bool gameSaved = false;
                    int index = 0;

                    while (gameSaved == false)
                    {
                        Game game = BuildGame(possibleGames, weekInfo, selection + index++);

                        if (context.Games.Count(g => g.Date == game.Date && g.HomeTeam == game.HomeTeam && g.AwayTeam == game.AwayTeam) == 0)
                        {
                            context.Games.Add(game);
                            context.SaveChanges();
                            gameSaved = true;
                        }
                    }
                }
            }

            return true;
        }

        private static Game BuildGame(List<Schedule> possibleGames, Week weekInfo, int selection)
        {
            if(selection >= 16)
            {
                selection = 0;
            }

            var selectedGame = possibleGames.ElementAt(selection);

            Game game = new Game();

            game.Date = selectedGame.Date;
            game.WeekId = weekInfo.Id;
            game.HomeTeam = selectedGame.HomeTeam.Name;
            game.AwayTeam = selectedGame.AwayTeam.Name;
            game.HomeTeamSpread = selectedGame.HomeTeamSpread;
            game.AwayTeamSpread = selectedGame.HomeTeamSpread * -1;
            game.OverUnder = selectedGame.OverUnder;
            return game;
        }

    }
}
