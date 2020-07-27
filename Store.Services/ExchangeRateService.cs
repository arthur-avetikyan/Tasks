using Store.DAL;
using Store.DAL.Infrastructure;
using Store.Entities;
using Store.IServices;

namespace Store.Services
{
    public class ExchangeRateService : Repository<ExchangeRate>, IExchangeRateService
    {
        public ExchangeRateService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
