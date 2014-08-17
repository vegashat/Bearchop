using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bearchop.LOTW.Core.Repository;
using Bearchop.LOTW.Core.Model;
using Bearchop.LOTW.Core.Service;
using Bearchop.Core.Models;
using Bearchop.Core.Services;

namespace Bearchop.Session
{
    public class BearchopSession
    {
        #region Constants

        const string SESSION_NAME = "BearchopSession";
        const string CURRENT_USER = "JUser";
        const string USER_ID = "JUserId";

        #endregion

        static BearchopSession _session = null;


        public static BearchopSession Current
        {
            get
            {
                var context = HttpContext.Current;
                _session = context.Session[SESSION_NAME] as BearchopSession;

                if (_session == null)
                {
                    _session = new BearchopSession();
                    context.Session[SESSION_NAME] = _session;
                }

                return _session;
            }
        }

        HttpContext Context
        {
            get
            {
                return HttpContext.Current;
            }
        }

        JUSER _user = null;
        public JUSER CurrentUser
        {

            get
            {
                JUserService userService = new JUserService();

                if (_user == null)
                {
                    //Try and get the cookie
                    var userId = Context.Request.Cookies[USER_ID] == null ? "0" : Context.Request.Cookies[USER_ID].Value.ToString();

                    int id = 0;
                    Int32.TryParse(userId, out id);

                    if (id != 0)
                    {
                        _user = userService.LoadUser(id);

                        SetCookie();
                    }
                }

                return _user;
            }

            set
            {
                _user = value;
                SetCookie();
            }
        }

        LOTWUser _lotwUser = null;
        public LOTWUser CurrentLOTWUser
        {
            get
            {
                JUserService userService = new JUserService();

                if (_lotwUser == null)
                {
                    //Try and get the cookie
                    var userId = Context.Request.Cookies[USER_ID] == null ? "0" : Context.Request.Cookies[USER_ID].Value.ToString();

                    int id = 0;
                    Int32.TryParse(userId, out id);

                    if (id != 0)
                    {
                        var juser = userService.LoadUser(id);
                        if (juser != null)
                        {
                            var service = new UserService();
                            _lotwUser = service.GetUser(id);

                            if (_lotwUser == null)
                            {
                                _lotwUser = new LOTWUser();
                                _user.UserID = juser.UserID;
                                _user.Name = juser.UserName;

                                service.SaveUser(_lotwUser);
                            }

                            SetCookie();
                        }
                    }
                }

                return _lotwUser;
            }

            set
            {
                _lotwUser = value;
                SetCookie();
            }
        }

        private void SetCookie()
        {
            HttpCookie cookie = new HttpCookie(USER_ID, _user.UserID.ToString());
            cookie.Expires = DateTime.Now.AddYears(999);

            Context.Response.SetCookie(cookie);

            Context.Session[CURRENT_USER] = _user;
        }
    }
}