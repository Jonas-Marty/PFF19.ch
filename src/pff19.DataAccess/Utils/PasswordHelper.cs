using System.Linq;
using System.Security.Cryptography;
using System.Text;
using pff19.DataAccess.Models;

namespace pff19.DataAccess.Utils
{
    public static class PasswordHelper
    {
        private static readonly SHA512 Sha512 = new SHA512Managed();
        private static readonly RNGCryptoServiceProvider Random = new RNGCryptoServiceProvider();

        public static byte[] GenerateUserSalt()
        {
            byte[] salt = new byte[64];
            Random.GetBytes(salt);
            return salt;
        }

        public static bool ValidatePassword(string loginPassword, User user)
        {
            return user.PasswordHash.SequenceEqual(GeneratePasswordHash(loginPassword, user.Salt));
        }

        public static byte[] GeneratePasswordHash(string password, byte[] salt)
        {
            return Sha512.ComputeHash(Encoding.UTF8.GetBytes(password).Concat(salt).ToArray());
        }
    }
}
