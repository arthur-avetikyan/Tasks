using Store.DTO;
using Store.IServices;
using System;
using System.Threading.Tasks;

namespace Market
{
    public class ApplicationStart
    {
        IProductService _productService;

        public ApplicationStart(IProductService productService)
        {
            _productService = productService;
        }

        public async Task Run()
        {
            foreach (ProductDTO item in _productService.GetTopSellingProducts(5))
            {
                Console.WriteLine(item.ProductName, item.Cost);
            }

            foreach (ProductInStockDTO item in _productService.GetFiltered())
            {
                Console.WriteLine(item.Name, item.InStock);
            }
        }
    }
}