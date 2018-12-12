using DatingApp.BLL.Helper;
using DatingApp.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatingApp.BLL.Interface
{
    public interface IUserService
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExist(string username);
        Task<User> GetUserById(int id);
        Task<User> GetUserByName(string name);
        Task<PagedList<User>> GetUsers(UserParams userParams);
        Task<IEnumerable<int>> GetUserLikes(int id, bool likers);
    }
}
