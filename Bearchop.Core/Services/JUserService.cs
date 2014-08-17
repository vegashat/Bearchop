using Bearchop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bearchop.Core.Services
{
    public class JUserService
    {
        JeauxDBContext _jeauxContext = new JeauxDBContext();

        public JUSER LoadUser(int userId)
        {
            return _jeauxContext.JUSERs.Where(j => j.UserID == userId).FirstOrDefault();
        }

        public JUSER ValidateUser(string username, string password)
        {
            var scrambler = new SHA1CryptoServiceProvider();
            byte[] pwBytes = scrambler.ComputeHash(Encoding.Unicode.GetBytes(password));
            string hashedPW = string.Empty;

            foreach (byte b in pwBytes)
            {
                hashedPW += string.Format("{0,2:X2}", b);
            }

            var user = _jeauxContext.JUSERs.Where(j => j.UserName == username && j.Password == hashedPW).FirstOrDefault();

            return user;
        }
    }
}
