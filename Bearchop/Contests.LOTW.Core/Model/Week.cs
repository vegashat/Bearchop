using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace Contests.LOTW.Core.Model
{
    public class Week
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

        List<Game> Games { get; set; }
    }
}
