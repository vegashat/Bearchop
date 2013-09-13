using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class vw_FRIENDS
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Pod { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Nullable<decimal> CellPhone { get; set; }
        public Nullable<decimal> HomePhone { get; set; }
        public string Location { get; set; }
        public string LocationSort { get; set; }
        public Nullable<int> UID { get; set; }
        public Nullable<int> FID { get; set; }
        public Nullable<byte> Status { get; set; }
        public Nullable<int> Initiator { get; set; }
        public string StatusText { get; set; }
    }
}
