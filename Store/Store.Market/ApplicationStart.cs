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
          await  _productService.AddProduct(new ProductDTO
            {
                Name = "Bezoar",
                Price = new PriceDTO
                {
                    Cost = 500,
                    Currency = "Amd",
                },
                Stock = new StockDTO
                {
                    InStock = 10
                }
            });

            foreach (var item in _productService.GetTopSellingProducts(5))
            {
                Console.WriteLine(item.Name, item.Price.Cost);
            }
        }
    }
}