using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contests.LOTW.Core.Model;

<<<<<<< HEAD
namespace Bearchop.LOTW.ViewModels
=======
namespace Bearchop.Areas.LOTW.Web.ViewModels
>>>>>>> 0297af5bd1bc700c06e6327a3527d72f11f3b1fc
{
    public class WeeksViewModel
    {
        public WeeksViewModel(IEnumerable<Week> weeks, Week currentWeek)
        {
            Weeks       = weeks;
            CurrentWeek = currentWeek;
        }

        public IEnumerable<Week> Weeks { get; set; }
        public Week CurrentWeek  { get; set; }
    }
}