using Store.Entities;
using System.Threading.Tasks;

namespace Store.DAL.Infrastructure
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntityBase;

        void Save();

        Task SaveAsync();
    }
}
