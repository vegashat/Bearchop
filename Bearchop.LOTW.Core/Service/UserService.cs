using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bearchop.LOTW.Core.Models;


namespace Bearchop.LOTW.Core.Service
{
    public class UserService
    {
        LOTWContext _context = new LOTWContext();
        public LOTWUser GetUser(int id)
        {
            return _context.Users.Include("Picks").FirstOrDefault(user => user.Id == id);
        }

        public IQueryable<LOTWUser> GetUsers()
        {
            var users = (from u in _context.Users.Include("Picks")
                        where u.Picks.Count > 0
                        select u).Distinct();

            return users;
        }

        public void SaveUser(LOTWUser user)
        {
            if (_context.Users.Count(u => u.Id == user.Id) > 0)
            {
                _context.Users.Attach(user);
                _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                _context.Users.Add(user);
            }
                
            _context.SaveChanges();
        }
    }
}
