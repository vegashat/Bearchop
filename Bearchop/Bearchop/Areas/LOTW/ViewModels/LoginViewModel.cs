using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOTW.Web.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel(string returnUrl)
        {
            ReturnUrl = returnUrl;
            Message   = string.Empty;
        }

        public LoginViewModel(string returnUrl, string message)
        {
            ReturnUrl = returnUrl;
            Message   = message;
        }
                
        public string ReturnUrl { get; private set; }
        public string Message   { get; private set; }
    }
}