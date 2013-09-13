using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class BASEBALL
    {
        public short Year { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string ALEast { get; set; }
        public string ALCent { get; set; }
        public string ALWest { get; set; }
        public string ALWild { get; set; }
        public string ALWild2 { get; set; }
        public string NLEast { get; set; }
        public string NLCent { get; set; }
        public string NLWest { get; set; }
        public string NLWild { get; set; }
        public string NLWild2 { get; set; }
        public string Champion { get; set; }
        public string ALMVP { get; set; }
        public string NLMVP { get; set; }
        public string ALCY { get; set; }
        public string NLCY { get; set; }
        public string ALRookie { get; set; }
        public string NLRookie { get; set; }
        public string ALManager { get; set; }
        public string NLManager { get; set; }
        public string HRLeader { get; set; }
        public string HRCount { get; set; }
        public Nullable<decimal> HRPoints { get; set; }
        public string RBILeader { get; set; }
        public string RBICount { get; set; }
        public Nullable<decimal> RBIPoints { get; set; }
        public Nullable<decimal> Points { get; set; }
    }
}
