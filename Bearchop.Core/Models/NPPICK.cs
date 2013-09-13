using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class NPPICK
    {
        public int PickID { get; set; }
        public int UserId { get; set; }
        public System.DateTime PickDateTime { get; set; }
        public string SeriesId { get; set; }
        public Nullable<int> PickedBeforeGame { get; set; }
        public string TeamPickId { get; set; }
        public Nullable<int> GamePick { get; set; }
        public Nullable<int> PotentialPoints { get; set; }
        public Nullable<int> Points { get; set; }
        public Nullable<bool> ActivePick { get; set; }
    }
}
