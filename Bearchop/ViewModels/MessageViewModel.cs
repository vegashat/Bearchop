using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Bearchop.ViewModels
{
    public class MessageViewModel
    {
        public MessageViewModel(string toList, string subject, string body, bool isHtml = false)
        {
            ToList  = toList;
            Subject = subject;
            Body    = body;
            IsHtml  = isHtml;
        }

        [Display(Name="Recipients")]
        public string ToList  { get; set; }
        public string Subject { get; set; }
        public string Body    { get; set; }
        public bool IsHtml    { get; set; }
    }
}