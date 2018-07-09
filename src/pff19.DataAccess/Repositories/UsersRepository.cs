using System;
using System.Collections.Generic;
using System.Text;
using pff19.DataAccess.Models;

namespace pff19.DataAccess.Repositories
{
    public class UsersRepository
    {
        private readonly PffContext _context;

        public UsersRepository(PffContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User Get(int id)
        {
            return _context.Users.Find(id);
        }

        public User Add(User sponsor)
        {
            _context.Users.Add(sponsor);
            _context.SaveChanges();
            return sponsor;
        }

        public void Update(User existingUser)
        {
            _context.Users.Update(existingUser);
            _context.SaveChanges();
        }

        public void Delete(User userToDelete)
        {
            _context.Users.Remove(userToDelete);
            _context.SaveChanges();
        }
    }
}
