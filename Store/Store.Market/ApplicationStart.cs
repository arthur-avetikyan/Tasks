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
            //_productService.AddProduct(new ProductDTO
            //{
            //    Category = new ProductCategoryDTO
            //    {
            //        CategoryName = "Stationary",
            //        CategoryTag = "Writing"
            //    },
            //    ProductName = "Pen",
            //    Cost = 150,
            //    Stock = new StockDTO
            //    {
            //        InStock = 120
            //    }
            //});

            _productService.GetProduct("Pen");

            //foreach (ProductInStockDTO item in _productService.GetFilteredEnumarable(2))
            //{
            //    Console.WriteLine(item.ProductName, item.InStock);
            //}

            //foreach (ProductInStockDTO item in _productService.GetFilteredQueryable(2))
            //{
            //    Console.WriteLine(item.ProductName, item.InStock);
            //}
        }
    }
}