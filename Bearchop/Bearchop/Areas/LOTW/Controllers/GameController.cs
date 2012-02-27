using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contests.LOTW.Core.Service;
using Contests.LOTW.Core.Model;
<<<<<<< HEAD
using Bearchop.LOTW.ViewModels;
using Bearchop.ActionFilter;

namespace Bearchop.LOTW.Controllers
=======
using Bearchop.Areas.LOTW.Web.ViewModels;
using Bearchop.ActionFilter;

namespace Bearchop.Areas.LOTW.Web.Controllers
>>>>>>> 0297af5bd1bc700c06e6327a3527d72f11f3b1fc
{
    [ValidateUser]
    public class GameController : Controller
    {
        GameService _gameService = new GameService();
        WeekService _weekService = new WeekService();

        public ActionResult List(int? week = null)
        {
            var model = GetGameModel(week);

            return View(model);
        }

        public PartialViewResult GameList(int week)
        {
            return PartialView("_GameList", GetGameModel(week));
        }

        private GamesViewModel GetGameModel(int? week = null)
        {
            var currentWeek = _weekService.GetWeek(week);
            var weeks = _weekService.GetWeeks();
            var games = _gameService.GetGames(week);
            var model = new GamesViewModel(games.ToList(), weeks.ToList(), currentWeek);
            return model;
        }

        public ActionResult NotFinalized()
        {
            var week = _weekService.GetWeek();
            var weeks = _weekService.GetWeeks();
            var games = _gameService.GetNonFinalizedGames();
            var model = new GamesViewModel(games.ToList(), weeks.ToList(), week);

            return View("List", model);
        }

        public PartialViewResult Add(int? id = null)
        {
            var game = new Game();
            if (id.HasValue)
            {
                game = _gameService.GetGame(id.Value);
            }

            return PartialView("_Add", game);
        }

        [HttpPost]
        public PartialViewResult Save([Bind(Prefix="")] Game game)
        {
            _gameService.SaveGame(game);
            
            return PartialView("_GameList", GetGameModel());
        }

        [HttpPost]
        public ActionResult Load(int week)
        {
            var currentWeek = _weekService.GetWeek(week);

            _gameService.LoadGames(currentWeek.Number);

            return RedirectToAction("List");
        }

    }
}
