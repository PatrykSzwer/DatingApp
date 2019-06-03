using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DatingApp.Model.Helpers
{
    internal static class PasswordHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512()) // Generates random key when initialized.
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt)) // Generates random key when initialized.
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                return passwordHash.SequenceEqual(computedHash);
            }
        }
    }
}
