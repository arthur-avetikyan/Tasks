using Store.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Store.DAL.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class, IEntityBase
    {
        void Insert(TEntity entity);

        Task InsertRange(IEnumerable<TEntity> entities);

        void Delete(Guid id);

        void DeleteRange(IEnumerable<TEntity> entities);

        TEntity GetById(Guid id);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
    }
}
