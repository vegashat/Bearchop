using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mail;
using Contests.LOTW.Core.Model;

namespace Bearchop.Mailers
{
    public interface IUserMailer
    {
        MailMessage MailCurrentPicks(Week week, IList<Pick> picks);
    }
}