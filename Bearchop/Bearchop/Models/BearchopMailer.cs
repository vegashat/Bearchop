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
            var email = new MailMessage("vegashat@gmail.com", to);

            email.Subject = subject;
            email.CC.Add("vegashat@gmail.com");
            email.Body = body;

            var client = new SmtpClient();
            client.Send(email);
        }

    }
}