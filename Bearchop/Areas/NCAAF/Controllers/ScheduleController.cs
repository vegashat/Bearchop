using Bearchop.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bearchop.Areas.NCAAF.Controllers
{
    public class ScheduleController : Controller
    {
        ScheduleService _scheduleService;

        public ScheduleController()
        {
            _scheduleService = new ScheduleService();
        }

        //
        // GET: /NCAAF/Schedule/

        public ActionResult Index()
        {
            return View();
        }   

        public JsonResult CurrentSchedule(int userId)
        {
            var schedule = _scheduleService.GetUserSchedule(userId);

            return Json(schedule, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AvailableTeams(int userId, int teamId)
        {
            var availableTeams = _scheduleService.GetAvailableTeams(userId, teamId);

            return Json(availableTeams, JsonRequestBehavior.AllowGet);
        }
    }
}
