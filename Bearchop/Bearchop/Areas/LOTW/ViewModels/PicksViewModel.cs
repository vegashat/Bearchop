﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contests.LOTW.Core.Model;
using Bearchop.Session;

<<<<<<< HEAD
namespace Bearchop.LOTW.ViewModels
=======
namespace Bearchop.Areas.LOTW.Web.ViewModels
>>>>>>> 0297af5bd1bc700c06e6327a3527d72f11f3b1fc
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