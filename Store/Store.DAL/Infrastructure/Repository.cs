using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Store.DAL.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;

        public Repository(MarketDbContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public void Insert(TEntity entity) => _dbSet.Add(entity);

        public async Task InsertRange(IEnumerable<TEntity> entities) => await _dbSet.AddRangeAsync(entities);

        public void Update(TEntity entity) => _dbSet.Update(entity);

        public void UpdateRange(IEnumerable<TEntity> entities) => _dbSet.UpdateRange(entities);

        public void Delete(TEntity entity) => _dbSet.Remove(entity);

        public void DeleteRange(IEnumerable<TEntity> entities) => _dbSet.RemoveRange(entities);

        public TEntity GetById(object id) => _dbSet.Find(id);

        public IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            if (orderBy != null)
                return orderBy(query).AsNoTracking().AsEnumerable();
            else
                return query.AsNoTracking().AsEnumerable();
        }

        //provide IQueryable?
        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query;
        }
    }
}
