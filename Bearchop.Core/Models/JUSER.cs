using System;
using System.Collections.Generic;

namespace Bearchop.Core.Models
{
    public class JUSER
    {
        public JUSER()
        {
            this.JFRIENDs = new List<JFRIEND>();
            this.RESUMEs = new List<RESUME>();
        }

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public Nullable<bool> ActiveFlag { get; set; }
        public string Email { get; set; }
        public string Pod { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Nullable<decimal> CellPhone { get; set; }
        public Nullable<decimal> HomePhone { get; set; }
        public Nullable<bool> BBSBanFlag { get; set; }
        public Nullable<byte> BdayMonth { get; set; }
        public Nullable<byte> BdayDay { get; set; }
        public Nullable<byte> AnnvMonth { get; set; }
        public Nullable<byte> AnnvDay { get; set; }
        public string Spouse { get; set; }
        public Nullable<short> LoyaltyUpdated { get; set; }
        public string MLB { get; set; }
        public string NFL { get; set; }
        public string NCF { get; set; }
        public string NCB { get; set; }
        public string NBA { get; set; }
        public string NHL { get; set; }
        public string Website { get; set; }
        public string Location { get; set; }
        public string LocationSort { get; set; }
        public Nullable<System.Guid> Reminder { get; set; }
        public string Comments { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public Nullable<short> FamilyID { get; set; }
        public virtual ICollection<JFRIEND> JFRIENDs { get; set; }
        public virtual ICollection<RESUME> RESUMEs { get; set; }
        public bool Notify { get; set; }
    }
}
