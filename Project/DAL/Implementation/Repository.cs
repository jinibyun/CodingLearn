using DatingApp.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DatingApp.Data.Implementation
{
    // note : IRepostiry and Repostory class is just general. There is nothing to do with special application
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> _entities;
        public Repository(DbContext context)
        {
            Context = context;
            _entities = Context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            IQueryable<TEntity> iEntities = _entities;
            //Apply eager loading
            foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                iEntities = _entities.Include<TEntity, object>(navigationProperty);

            return await iEntities.AsNoTracking().ToListAsync<TEntity>();                
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            IQueryable<TEntity> iEntities = _entities;
            //Apply eager loading
            foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                iEntities = _entities.Include<TEntity, object>(navigationProperty);

            return await iEntities
                .AsNoTracking()
                .Where(where)
                .AsQueryable()
                .ToListAsync<TEntity>();
        }

        public async Task<TEntity> GetSingleAsync(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            IQueryable<TEntity> iEntities = _entities;

            //Apply eager loading
            foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                iEntities = _entities.Include<TEntity, object>(navigationProperty);

            //return iEntities
            //       .AsNoTracking() //Don't track any changes for the selected item
            //       .Where(where)
            //       .FirstOrDefault<TEntity>();
            return await Task.FromResult(iEntities
                   .AsNoTracking() //Don't track any changes for the selected item
                   .Where(where)
                   .FirstOrDefault<TEntity>());
        }        

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }

        
    }
}
