using Microsoft.EntityFrameworkCore;
using Store.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

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

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbSet.AsQueryable<TEntity>();
        }

        public TEntity GetById(Guid id)
        {
            return dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }

        public IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
                return orderBy(query);
            else
                return query;
        }
    }
}
