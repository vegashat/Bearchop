using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace Bearchop.Models
{
    public class BearchopMailer
    {            
        public void Send(string to, string subject, string body)
        {
            var email = new MailMessage("vegashat@bearchop.com", to);

            email.Subject = subject;
            email.CC.Add("vegashat@bearchop.com");
            email.Body = body;

            var client = new SmtpClient();
            client.Send(email);
        }

    }
}