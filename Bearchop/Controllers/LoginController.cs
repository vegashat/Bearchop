using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bearchop.Session;
using Bearchop.LOTW.Core.Repository;
using Bearchop.ViewModels;
using Bearchop.Core.Services;

namespace Bearchop.Controllers
{
    public class LoginController : Controller
    {
        JUserService _jUserService = new JUserService();

        public ActionResult Login(string returnUrl = "Success")
        {
            return View(new LoginViewModel(returnUrl));
        }

        [HttpPost]
        public ActionResult Login(string username, string password, string returnUrl)
        {
            try
            {
                var user = _jUserService.ValidateUser(username, password);

                if (user != null)
                {
                    BearchopSession.Current.CurrentUser = user;

                    return new RedirectResult(returnUrl);
                }
                else
                {
                    return View(new LoginViewModel(returnUrl, "Invalid Username and/or Password, Try again."));
                }
            }
            catch (Exception ex)
            {
                return View(new LoginViewModel(returnUrl, "Something broke, here it is : " + ex.ToString()));
            }
        }

    }
}
