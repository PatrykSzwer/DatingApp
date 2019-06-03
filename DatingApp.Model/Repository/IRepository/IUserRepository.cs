using DatingApp.Model.Models;
using System.Threading.Tasks;

namespace DatingApp.Model.Repository.IRepository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> Register(string username, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
