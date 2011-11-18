using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bearchop.ActionFilter;
using Contests.LOTW.Core.Service;

namespace Bearchop.LOTW.Controllers
{
    [ValidateUser]
    public class WeekController : Controller
    {
        GameService _gameService = new GameService();
        PickService _pickService = new PickService();
        WeekService _weekService = new WeekService();

        public ActionResult Index()
        {
            return View();   
        }

    }
}
