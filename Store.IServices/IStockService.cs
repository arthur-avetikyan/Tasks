using Store.DAL.Infrastructure;
using Store.Entities;

namespace Store.IServices
{
    public interface IStockService : IRepository<Stock>
    {
    }
}
