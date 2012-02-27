using System.Web.Mvc;

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
                "NCAAF/{controller}/{action}",
<<<<<<< HEAD
                new { controller = "schedule", action = "Index" },
                new string[] { "Bearchop.NCAAF.Controllers" }
=======
                new { controller = "schedule", action = "Index" }, new[] { "Bearchop.Areas.NCAAF.Web.Controllers" }
 
>>>>>>> 0297af5bd1bc700c06e6327a3527d72f11f3b1fc
            );
        }
    }
}
