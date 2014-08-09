using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Bearchop.Util
{
    public class Mail
    {
        public static void SendMail(string subject, string body, string recipient)
        {
            var recipients = new List<string>();
            recipients.Add(recipient);
            SendMail(subject, body, recipients);
        }

        public static void SendMail(string subject, string body, params string [] recipients)
        {
            var recipientsList = new List<string>();
            recipientsList.AddRange(recipients);
            SendMail(subject, body, recipientsList);
        }

        public static void SendMail(string subject, string body, ICollection<string> recipients)
        {
            var fromAddress = new MailAddress("chris@bearchop.com", "Bearchop");
            
            const string fromPassword = "alexander0426";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            var message = new MailMessage();

            message.From = fromAddress;
            message.Subject = subject;
            message.Body = body;

            var toList = string.Join(",", recipients);

            message.To.Add(toList);

            smtp.Send(message);
        }
    }
}
