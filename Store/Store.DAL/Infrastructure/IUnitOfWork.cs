using System.Threading.Tasks;

namespace Store.DAL.Infrastructure
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        void Save();

        Task SaveAsync();
    }
}
