using Microsoft.EntityFrameworkCore;
using Store.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Store.DAL.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntityBase
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<TEntity> dbSet;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public void Insert(TEntity entity) => dbSet.Add(entity);

        public async Task InsertRange(IEnumerable<TEntity> entities) => await dbSet.AddRangeAsync(entities);

        public void Update(TEntity entity) => dbSet.Update(entity);

        public void UpdateRange(IEnumerable<TEntity> entities) => dbSet.UpdateRange(entities);

        public void Delete(TEntity entity) => dbSet.Remove(entity);

        public void DeleteRange(IEnumerable<TEntity> entities) => dbSet.RemoveRange(entities);

        public TEntity GetById(Guid id) => dbSet.Find(id);

        public IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            foreach (string includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
                return orderBy(query).AsNoTracking().AsEnumerable();
            else
                return query.AsNoTracking().AsEnumerable();
        }
    }
}
