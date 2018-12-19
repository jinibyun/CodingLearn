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

        //public async Task<int> SaveChangesAsync()
        //{
        //    try
        //    {
        //        var a = await _repo.SaveChangesAsync();
        //        return a;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }            
        //}

        public bool AddPhoto(Photo photo)
        {
            _photo.Add(photo);
            return _repo.SaveChanges() > 0;
        }

        public void DeletePhoto(Photo photo)
        {
            _photo.Remove(photo);
        }
    }
}
