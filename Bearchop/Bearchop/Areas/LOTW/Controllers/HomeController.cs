using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bearchop.Areas.LOTW.Web.ViewModels;
using Contests.Core.Repository;
using Contests.LOTW.Core.Service;
using Bearchop.ActionFilter;
using Bearchop.Session;

namespace Bearchop.Areas.LOTW.Web.Controllers
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
