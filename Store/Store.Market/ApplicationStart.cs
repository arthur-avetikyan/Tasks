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
            _productService.AddProduct(new ProductDTO
            {
                Category = new ProductCategoryDTO
                {
                    CategoryName = "Stationary",
                    CategoryTag = "Writing"
                },
                ProductName = "Pen",
                Cost = 150,
                Stock = new StockDTO
                {
                    InStock = 120
                }

            });

            foreach (ProductDTO item in _productService.GetMostExpenciveProducts(1))
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