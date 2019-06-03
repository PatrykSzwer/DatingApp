using DatingApp.Model.Data;
using DatingApp.Model.Helpers;
using DatingApp.Model.Models;
using DatingApp.Model.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DatingApp.Model.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> Register(string username, string password)
        {
            var user = new User { Username = username };

            PasswordHelper.CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await this.Add(user);
            await this.SaveChanges();

            return user;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await this._context.Users.FirstOrDefaultAsync(x => x.Username == username);
            if (user == null)
            {
                return null;
            }

            if (!PasswordHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            return user;
        }

        public async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.Username == username);
        }
    }
}
