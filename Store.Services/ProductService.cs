using Store.DAL;
using Store.DAL.Infrastructure;
using Store.Entities;
using Store.IServices;

namespace Store.Services
{
    public class ProductService : Repository<Product>, IProductService
    {
        public ProductService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
