using Store.DAL;
using Store.DAL.Infrastructure;
using Store.Entities;
using Store.IServices;

namespace Store.Services
{
    public class StockService : Repository<Stock>, IStockService
    {
        public StockService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
