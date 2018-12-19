using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingApp.Data.Implementation;
using DatingApp.Data.Interface;

namespace DatingApp.Data
{
    public class DatingAppData : IDatingAppData
    {
        private readonly DatingAppEntities _context;

        public IRepository<Value> Value { get; private set; }
        public IRepository<User> User { get; private set; }
        public IRepository<Message> Message { get; private set; }
        public IRepository<Photo> Photo { get; private set; }
        public IRepository<Like> Like { get; private set; }

        public DatingAppData(DatingAppEntities context)
        {
            _context = context;
            Value = new Repository<Value>(_context);
            User = new Repository<User>(_context);
            Message = new Repository<Message>(_context);
            Photo = new Repository<Photo>(_context);
            Like = new Repository<Like>(_context);
        }


        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
