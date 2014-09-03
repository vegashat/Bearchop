using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bearchop.LOTW.Core.Models;

namespace Bearchop.Areas.LOTW.Web.ViewModels
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