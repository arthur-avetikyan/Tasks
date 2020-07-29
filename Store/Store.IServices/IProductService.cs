using Store.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.IServices
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetAllProducts();

        IEnumerable<ProductDTO> GetMostExpenciveProducts(int count);

        void AddProduct(ProductDTO product);

        Task AddProducts(IEnumerable<ProductDTO> products);

        IEnumerable<ProductInStockDTO> GetFiltered();
    }
}
