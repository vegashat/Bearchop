using System.Web.Mvc;

namespace Bearchop.Areas.LOTW
{
    public class LOTWAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "LOTW";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "LOTW_default",
                "LOTW/{controller}/{action}",
<<<<<<< HEAD
                new { controller = "home", action = "Index" },
                new string[] { "Bearchop.LOTW.Controllers" }
=======
                new { controller = "home", action = "Index" }, new[] { "Bearchop.Areas.LOTW.Web.Controllers" }
>>>>>>> 0297af5bd1bc700c06e6327a3527d72f11f3b1fc
            );
        }
    }
}
