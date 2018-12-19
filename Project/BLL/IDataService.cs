using DatingApp.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.BLL
{
    public interface IDataService
    {
        IUserService UserService { get; }
        IValueService ValueService { get; }
        ILikeService LikeService { get; }
        IPhotoService PhotoService { get; }
        IMessageService MessageService { get; }

    }
}
