using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Routing;
using Bearchop.Session;

namespace Bearchop.ActionFilter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class ValidateUser : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;

            var user = BearchopSession.Current.CurrentUser;

            if (user == null)
            {
                RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
                redirectTargetDictionary.Add("area", string.Empty);
                redirectTargetDictionary.Add("action", "login");
                redirectTargetDictionary.Add("controller", "login");
                redirectTargetDictionary.Add("returnUrl", ctx.Request.RawUrl);

                filterContext.Result = new RedirectToRouteResult(redirectTargetDictionary);
            }

            base.OnActionExecuting(filterContext);
        }
    }
}