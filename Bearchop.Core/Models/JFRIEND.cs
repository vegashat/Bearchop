using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class JFRIEND
    {
        public int UserID { get; set; }
        public int FriendID { get; set; }
        public byte Status { get; set; }
        public virtual JUSER JUSER { get; set; }
    }
}
