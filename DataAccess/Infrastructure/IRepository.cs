using Store.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Store.DAL.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class, IEntityBase
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(Guid id);

        void Insert(TEntity entity);

        void Delete(TEntity entity);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            string includeProperties);
    }
}
