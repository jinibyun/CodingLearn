using DatingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.BLL.Interface
{
    public interface ILikeService
    {
        Task<Like> GetLike(int userId, int recipientId);
        void AddLike(Like like);
        Task<int> SaveChangesAsync();
    }
}
