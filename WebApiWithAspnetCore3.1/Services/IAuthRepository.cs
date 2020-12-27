using System.Threading.Tasks;
using WebApiWithAspnetCore31.Models;

namespace WebApiWithAspnetCore31.Services
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);
         Task<User> Login(string username, string password);
         Task<bool> UserExists(string username);
    }
}