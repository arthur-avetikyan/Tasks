using System.Threading.Tasks;

namespace Store.DAL.Infrastructure
{
    public interface IUnitOfWork
    {
        void Save();

        Task SaveAsync();
    }
}
