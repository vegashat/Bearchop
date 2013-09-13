using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class REVIEW
    {
        public decimal ReviewID { get; set; }
        public string Title { get; set; }
        public System.DateTime ReviewDate { get; set; }
        public string ReviewType { get; set; }
        public Nullable<bool> RecentFlag { get; set; }
        public string Author { get; set; }
        public string Venue { get; set; }
        public string Attendees { get; set; }
        public string ImagePath { get; set; }
        public string Commentary { get; set; }
    }
}
