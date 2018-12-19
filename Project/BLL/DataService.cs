using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingApp.BLL.Implementation;
using DatingApp.BLL.Interface;
using DatingApp.Data;

namespace DatingApp.BLL
{
    public class DataService : IDataService
    {
        public IUserService UserService { get; private set; }
        public IValueService ValueService { get; private set; }        
        public IPhotoService PhotoService { get; private set; }
        public IMessageService MessageService { get; private set; }
        public ILikeService LikeService { get; private set; }

        public DataService(IDatingAppData _repo)
        {
            UserService = new UserService(_repo);
            ValueService = new ValueService(_repo);
            PhotoService = new PhotoService(_repo);
            MessageService = new MessageService(_repo);
            LikeService = new LikeService(_repo);
        }
    }
}
