using System.Threading.Tasks;

namespace DataAccess.Infrastructure
{
    public interface IUnitOfWork
    {
        void Save();

        Task SaveAsync();
    }
}
