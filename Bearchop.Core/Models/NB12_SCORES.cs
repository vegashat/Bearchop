using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class NB12_SCORES
    {
        public int Pick { get; set; }
        public byte Week { get; set; }
        public string UserName { get; set; }
        public Nullable<byte> SortOrder { get; set; }
        public string Player { get; set; }
        public string Pos { get; set; }
        public Nullable<short> Pass { get; set; }
        public Nullable<short> Rush { get; set; }
        public Nullable<short> Recv { get; set; }
        public Nullable<short> TD { get; set; }
        public Nullable<short> Turnovers { get; set; }
        public Nullable<short> Safeties { get; set; }
        public Nullable<short> PK3 { get; set; }
        public Nullable<short> PK5 { get; set; }
        public Nullable<short> XP { get; set; }
        public Nullable<short> PtsAllowed { get; set; }
        public Nullable<short> YdsAllowed { get; set; }
        public Nullable<short> Points { get; set; }
    }
}
