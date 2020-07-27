using Store.DAL;
using Store.DAL.Infrastructure;
using Store.Entities;
using Store.IServices;

namespace Store.Services
{
    public class PriceService : Repository<Price>, IPriceService
    {
        public PriceService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
