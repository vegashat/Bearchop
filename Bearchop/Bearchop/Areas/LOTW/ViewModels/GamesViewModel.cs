using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contests.LOTW.Core.Model;
using Bearchop.Session;

namespace Bearchop.Areas.LOTW.Web.ViewModels
{
    public class GamesViewModel
    {
        public GamesViewModel(IList<Game> games, IList<Week> weeks,  Week currentWeek, string pageTitle = "Current Games")
        {
            Games = games;
            Weeks = weeks;
            CurrentWeek = currentWeek;
            PageTitle = pageTitle;


            //Used for binding
            EmptyGame = new Game();
        }

        public Game EmptyGame { get; private set; }

        public IList<Game> Games { get; set; }

        public string PageTitle { get; set; }

        public LOTWUser CurrentUser
        {
            get
            {
                return BearchopSession.Current.CurrentLOTWUser;
            }
        }

        public Week CurrentWeek { get; set; }

        public IList<Week> Weeks { get; set; }
    }
}