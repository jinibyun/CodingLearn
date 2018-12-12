using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Data.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        // 1. get
        Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] navigationProperties);
        Task<IEnumerable<TEntity>> GetAllAsync(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] navigationProperties);
        Task<TEntity> GetSingleAsync(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] navigationProperties);

        // 2. add
        void Add(TEntity entity); // one object
        void AddRange(IEnumerable<TEntity> entities); // list object

        // 3. remove
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        // note: repository pattern shoud not have update because it handles collection of data
    }
}
