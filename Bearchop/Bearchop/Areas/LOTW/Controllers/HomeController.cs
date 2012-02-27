using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
<<<<<<< HEAD
using Bearchop.LOTW.ViewModels;
=======
using Bearchop.Areas.LOTW.Web.ViewModels;
>>>>>>> 0297af5bd1bc700c06e6327a3527d72f11f3b1fc
using Contests.Core.Repository;
using Contests.LOTW.Core.Service;
using Bearchop.ActionFilter;
using Bearchop.Session;

<<<<<<< HEAD
namespace Bearchop.LOTW.Controllers
=======
namespace Bearchop.Areas.LOTW.Web.Controllers
>>>>>>> 0297af5bd1bc700c06e6327a3527d72f11f3b1fc
{
    
    public class HomeController : Controller
    {
        UserService _userService = new UserService();
        WeekService _weekService = new WeekService();


        [ValidateUser]
        public ActionResult Index()
        {
            var users = _userService.GetUsers();
            var weeks = _weekService.GetWeeks();
            var currentWeek = _weekService.GetWeek();

            var model = new SummaryViewModel(users, weeks, currentWeek);

            return View(model);
        }


    }
}
