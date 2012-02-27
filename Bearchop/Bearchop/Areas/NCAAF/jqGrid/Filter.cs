using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization.Json;
using System.Text;

<<<<<<< HEAD
namespace Bearchop.NCAAF.jqGrid
=======
namespace Bearchop.Areas.NCAAF.Web.jqGrid
>>>>>>> 0297af5bd1bc700c06e6327a3527d72f11f3b1fc
{
    public class Filter
    {
        public string groupOp { get; set; }
        public Rule[] rules { get; set; }

        public static Filter Create(string jsonData)
        {
            try
            {
                var serializer = new DataContractJsonSerializer(typeof(Filter));
                System.IO.StringReader reader = new System.IO.StringReader(jsonData);
                System.IO.MemoryStream ms =
                    new System.IO.MemoryStream(Encoding.Unicode.GetBytes(jsonData));
                return serializer.ReadObject(ms) as Filter;
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}