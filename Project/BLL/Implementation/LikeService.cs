using DatingApp.BLL.Interface;
using DatingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.BLL.Implementation
{
    public class LikeService : BaseDataService, ILikeService
    {
        public LikeService(IDatingAppData repo) : base(repo)
        {

        }

        public void AddLike(Like like)
        {
            _like.Add(like);
        }

        public async Task<Like> GetLike(int userId, int recipientId)
        {
            return await _like.GetSingleAsync(x => x.LikeeId == userId && x.LikeeId == recipientId);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _repo.SaveChangesAsync();
        }
    }
}
