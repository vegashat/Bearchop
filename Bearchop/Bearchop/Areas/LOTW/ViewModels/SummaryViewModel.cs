using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contests.LOTW.Core.Model;
using Bearchop.Session;

namespace Bearchop.Areas.LOTW.Web.ViewModels
{
    public class SummaryViewModel
    {
        public SummaryViewModel(IEnumerable<LOTWUser> users, IEnumerable<Week> weeks, Week currentWeek)
        {
            Users       = users;
            Weeks       = weeks;
            CurrentWeek = currentWeek;
        }

        public LOTWUser CurrentUser
        {
            get
            {
                return BearchopSession.Current.CurrentLOTWUser;
            }
        }

        public IEnumerable<LOTWUser> Users { get; set; }
        public IEnumerable<Week> Weeks     { get; set; }
        public Week CurrentWeek            { get; set; }
        
    }
}