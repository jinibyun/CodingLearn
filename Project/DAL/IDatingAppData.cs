using DatingApp.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Data
{
    public interface IDatingAppData: IDisposable
    {
        IRepository<Value> Value { get; }
        IRepository<User> User { get; }
        IRepository<Message> Message { get; }
        IRepository<Photo> Photo { get; }
        Task<int> SaveChangesAsync();

    }
}
