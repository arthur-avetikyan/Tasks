using Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Infrastructure
{
    interface IRepository<TEntity> where TEntity : class, IEntityBase
    {
        IQueryable<TEntity> GetAll();

        TEntity GetById(Guid id);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            string includeProperties);
    }
}
