using System;
using System.Collections.Generic;
using System.Text;
using pff19.DataAccess.Models;
using pff19.DataAccess.Utils;

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

        public User Add(User user, string password)
        {
            SetPasswordAndSalt(user, password);

            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        private static void SetPasswordAndSalt(User user, string password)
        {
            user.Salt = PasswordHelper.GenerateUserSalt();
            user.PasswordHash = PasswordHelper.GeneratePasswordHash(password, user.Salt);
        }

        public void ChangePassword(User user, string newPassword)
        {
            SetPasswordAndSalt(user, newPassword);
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
