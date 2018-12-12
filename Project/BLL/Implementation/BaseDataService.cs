using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.Data;
using DatingApp.Data.Interface;

namespace DatingApp.BLL.Implementation
{
    public class BaseDataService
    {
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected IDatingAppData _repo;

        protected IRepository<Value> _value { get; private set; }
        protected IRepository<User> _user { get; private set; }
        protected IRepository<Message> _message { get; private set; }
        protected IRepository<Photo> _photo { get; private set; }

        public BaseDataService(IDatingAppData repo)
        {
            _repo = repo;
            _value = repo.Value;
            _user = _repo.User;
            _photo = _repo.Photo;
        }

        protected async Task<int> SaveChangesAsync()
        {
            return await _repo.SaveChangesAsync();
        }
    }
}
