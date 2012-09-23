using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mail;
using Contests.LOTW.Core.Model;
using Mvc.Mailer;

namespace Bearchop.Mailers
{
    public class UserMailer : MailerBase, IUserMailer
    {
        public UserMailer() :
            base()
        {
            MasterName = "_Layout";

        }

        public MailMessage MailCurrentPicks(string email, Week week, IList<Pick> picks)
        {
            var mailMessage = new MailMessage { Subject = "Picks for LOTW : ".+ week.Number.ToString() };
            mailMessage.To = email;


            ViewData.Model = picks;
            PopulateBody(mailMessage, viewName: "NewLineRequestWriting");
            return mailMessage;
        }


    }
}