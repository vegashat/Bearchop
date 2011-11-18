using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contests.LOTW.Core.Model;
using Bearchop.Session;

namespace Bearchop.LOTW.ViewModels
{
    public class PicksViewModel
    {
        public PicksViewModel(Week week, IList<Game> games, IList<Pick> picks, LOTWUser user)
        {
            PickWeek = week;
            Games    = games;
            Picks    = picks;
            User     = user;
        }

        public Week PickWeek     { get; set; }
        public IList<Game> Games { get; set; }
        public IList<Pick> Picks { get; set; }
        public LOTWUser User     { get; set; }

        public Pick PickForGame(Game game)
        {
            return Picks.FirstOrDefault(pick => pick.GameId == game.Id);
        }
        
        public Game GameForPick(Pick pick)
        {
            return Games.FirstOrDefault(game => game.Id == pick.GameId);
        }


        public LOTWUser CurrentUser
        {
            get
            {
                return BearchopSession.Current.CurrentLOTWUser;
            }
        }

        public bool ViewingPicksForCurrentUser
        {
            get
            {
                return User.Id == CurrentUser.Id;
            }
        }

        public bool GamesHaveStarted
        {
            get
            {
                return Games.Count(game => game.Date <= DateTime.Now) > 0;
            }
        }
        
    }
}