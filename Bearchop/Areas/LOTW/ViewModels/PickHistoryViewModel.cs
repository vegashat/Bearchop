using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bearchop.LOTW.Core.Model;

namespace Bearchop.Areas.LOTW.Web.ViewModels
{
    public class PickHistoryViewModel : WeeksViewModel
    {
        public PickHistoryViewModel(int userId, IEnumerable<Week> weeks, Week currentWeek) : base(weeks, currentWeek)
        {
            UserId = userId;
        }

        public int UserId { get; set; }
    }
}