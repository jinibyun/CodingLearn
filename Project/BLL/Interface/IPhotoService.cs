using DatingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.BLL.Interface
{
    public interface IPhotoService
    {
        Task<Photo> GetMainPhotoForUser(int userId);
        Task<Photo> GetPhoto(int id);
        void DeletePhoto(Photo message);
        //Task<int> SaveChangesAsync();
        //bool SaveChanges();
        bool AddPhoto(Photo photo);
    }
}
