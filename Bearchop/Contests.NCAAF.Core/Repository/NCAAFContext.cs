using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contests.NCAAF.Core
{
    public class NCAAFContext
    {
        public static NCAAFEntities GetNcaaEntities()
        {
            return new NCAAFEntities();
        }

        public static JeauxDBEntities GetJeauxDBEntities()
        {
            return new JeauxDBEntities();
        }
    }
}
