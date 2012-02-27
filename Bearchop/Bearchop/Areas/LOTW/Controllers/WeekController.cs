using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bearchop.ActionFilter;
using Contests.LOTW.Core.Service;

<<<<<<< HEAD
namespace Bearchop.LOTW.Controllers
=======
namespace Bearchop.Areas.LOTW.Web.Controllers
>>>>>>> 0297af5bd1bc700c06e6327a3527d72f11f3b1fc
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
