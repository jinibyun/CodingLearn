using DatingApp.BLL.Interface;
using DatingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.BLL.Implementation
{
    public class PhotoService: BaseDataService, IPhotoService
    {
        public PhotoService(IDatingAppData repo) : base(repo)
        {

        }

        public async Task<Photo> GetMainPhotoForUser(int userId)
        {
            return await _photo.GetSingleAsync(u => u.UserId == userId && u.IsMain);                
        }

        public async Task<Photo> GetPhoto(int id)
        {
            return await _photo.GetSingleAsync(p => p.Id == id);
        }
    }
}
