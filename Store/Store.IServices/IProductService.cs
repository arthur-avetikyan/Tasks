using Store.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.IServices
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetAllProducts();

        IEnumerable<ProductDTO> GetTopSellingProducts(int count);

        Task AddProduct(ProductDTO product);
    }
}
