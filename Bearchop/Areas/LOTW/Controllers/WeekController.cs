﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bearchop.ActionFilter;
using Bearchop.LOTW.Core.Service;

namespace Bearchop.Areas.LOTW.Web.Controllers
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
