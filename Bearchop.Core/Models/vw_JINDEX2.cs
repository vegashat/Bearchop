using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class vw_JINDEX2
    {
        public Nullable<long> Rank { get; set; }
        public Nullable<int> JIndex { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public Nullable<int> ContestCount { get; set; }
        public Nullable<int> PlaceAvg { get; set; }
        public Nullable<decimal> FinishAvg { get; set; }
        public Nullable<int> FinishPoints { get; set; }
        public Nullable<int> ChampionCount { get; set; }
        public Nullable<int> MVPCount { get; set; }
        public Nullable<int> AllStarCount { get; set; }
        public Nullable<int> StarCount { get; set; }
        public string XFactor { get; set; }
        public Nullable<decimal> RawXFactor { get; set; }
        public string BonusPlace { get; set; }
        public string BonusContest { get; set; }
        public Nullable<short> BestFinish { get; set; }
    }
}
