using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Configuration;

namespace Contests.Core.Repository
{
    public partial class JUSER : EntityObject
    {
        public static Func<CoreEntities, string, string, JUSER> GetJUser =
                    CompiledQuery.Compile((CoreEntities context, string username, string password) =>
                                           (from j in context.JUSERs
                                            where j.UserName == username
                                               && j.Password == password
                                            select j).FirstOrDefault());

        public static Func<CoreEntities, int, JUSER> GetJUserByID =
                    CompiledQuery.Compile((CoreEntities context, int userID) =>
                                           (from j in context.JUSERs
                                            where j.UserID == userID
                                            select j).FirstOrDefault());

        public JUSER() { }

        public static JUSER ValidateUser(string username, string password)
        {
            var scrambler = new SHA1CryptoServiceProvider();
            byte[] pwBytes = scrambler.ComputeHash(Encoding.Unicode.GetBytes(password));
            string hashedPW = string.Empty;

            foreach (byte b in pwBytes)
            {
                hashedPW += string.Format("{0,2:X2}", b);
            }

            using (var context = GetContext())
            {
                return GetJUser(context, username, hashedPW);              
            }
        }

        public static JUSER LoadUser(int userId)
        {
            using (var context = GetContext())
            {
                return GetJUserByID(context, userId);
            }
        }
        
        protected static CoreEntities GetContext()
        {
            return new CoreEntities(ConfigurationManager.ConnectionStrings["CoreEntities"].ToString());
        }
    }
}
