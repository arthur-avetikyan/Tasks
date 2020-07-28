using Store.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.IServices
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetAllProducts();

        IEnumerable<ProductDTO> GetTopSellingProducts(int count);

        void AddProduct(ProductDTO product);

        Task AddProducts(IEnumerable<ProductDTO> products);
    }
}
