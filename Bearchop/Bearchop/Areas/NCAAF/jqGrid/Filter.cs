using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Contests.NCAAF.Web.jqGrid
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