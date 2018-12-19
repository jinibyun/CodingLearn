using DatingApp.BLL.Helper;
using DatingApp.BLL.Interface;
using DatingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace DatingApp.BLL.Implementation
{
    public class UserService : BaseDataService, IUserService
    {
        public UserService(IDatingAppData repo) : base(repo)
        {
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _user.GetSingleAsync(x => x.Username == username);
            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public async Task<bool> UserExist(string username)
        {
            var user = await _user.GetSingleAsync(x => x.Username == username);
            if (user == null)
                return false;
            return true;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            _repo.User.Add(user);

            await SaveChangesAsync();
            return user;
        }        

        public async Task<User> GetUserById(int id)
        {
            var user = await _user.GetSingleAsync(x => x.Id == id);
            return user;
        }

        public async Task<User> GetUserByName(string name)
        {
            var user = await _user.GetSingleAsync(x => x.Username == name);
            return user;
        }

        public async Task<PagedList<User>> GetUsers(UserParams userParams)
        {
            var users = await _user.GetAllAsync();
            users = users.OrderByDescending(u => u.LastActive).AsQueryable();
            users = users.Where(u => u.Id != userParams.UserId);
            users = users.Where(u => u.Gender == userParams.Gender);

            if (userParams.Likers)
            {
                var userLikers = await GetUserLikes(userParams.UserId, userParams.Likers);
                users = users.Where(u => userLikers.Contains(u.Id));
            }

            if (userParams.Likees)
            {
                var userLikees = await GetUserLikes(userParams.UserId, userParams.Likers);
                users = users.Where(u => userLikees.Contains(u.Id));
            }

            if (userParams.MinAge != 18 || userParams.MaxAge != 99)
            {
                var minDob = DateTime.Today.AddYears(-userParams.MaxAge - 1);
                var maxDob = DateTime.Today.AddYears(-userParams.MinAge);

                users = users.Where(u => u.DateOfBirth >= minDob && u.DateOfBirth <= maxDob);
            }

            if (!string.IsNullOrEmpty(userParams.OrderBy))
            {
                switch (userParams.OrderBy)
                {
                    case "created":
                        users = users.OrderByDescending(u => u.Created);
                        break;
                    default:
                        users = users.OrderByDescending(u => u.LastActive);
                        break;
                }
            }

            return PagedList<User>.CreateAsync(users.AsQueryable<User>(), userParams.PageNumber, userParams.PageSize);
        }

        public async Task<IEnumerable<int>> GetUserLikes(int id, bool likers)
        {
            var user = await _user.GetSingleAsync(x => x.Id == id, x=>x.Likes, x=>x.Likes1);
            

            if (likers)
            {
                
                return user.Likes.Where(u => u.LikeeId == id).Select(i => i.LikerId);
            }
            else
            {
                return user.Likes1.Where(u => u.LikerId == id).Select(i => i.LikeeId);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _repo.SaveChangesAsync();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }        
    }
}
