﻿using System.Web.Mvc;

namespace Bearchop.Areas.NCAAF
{
    public class NCAAFAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "NCAAF";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "NCAAF_default",
                "NCAAF/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
