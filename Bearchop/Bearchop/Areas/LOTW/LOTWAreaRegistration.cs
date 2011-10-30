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
                new { controller="home", action = "Index"}
            );
        }
    }
}
