using Store.DTO;
using Store.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market
{
    public class ApplicationStart
    {
        IProductService _productService;
        IPriceService _priceService;

        public ApplicationStart(IProductService productService, IPriceService priceService)
        {
            _productService = productService;
            _priceService = priceService;
        }

        public async Task Run()
        {
            await _productService.AddProducts(new List<ProductDTO>
            {
                new ProductDTO
                {
                    Name = "Pen",
                    Price = new PriceDTO
                    {
                        Cost = 5,
                        Currency = "USD"
                    },
                    Stock = new StockDTO
                    {
                        InStock = 100
                    }
                },
                new ProductDTO
                {
                    Name = "Pencil",
                    Price = new PriceDTO
                    {
                        Cost = 3,
                        Currency = "USD"
                    },
                    Stock = new StockDTO
                    {
                        InStock = 100
                    }
                },
                new ProductDTO
                {
                    Name = "Notebook",
                    Price = new PriceDTO
                    {
                        Cost = 6,
                        Currency = "USD"
                    },
                    Stock = new StockDTO
                    {
                        InStock = 100
                    }
                },
                new ProductDTO
                {
                    Name = "TextBook",
                    Price = new PriceDTO
                    {
                        Cost = 12,
                        Currency = "USD"
                    },
                    Stock = new StockDTO
                    {
                        InStock = 100
                    }
                },
                new ProductDTO
                {
                    Name = "Rubber",
                    Price = new PriceDTO
                    {
                        Cost = 2,
                        Currency = "USD"
                    },
                    Stock = new StockDTO
                    {
                        InStock = 100
                    }
                },
            });

            _priceService.DropPrice(_productService
                .GetTopSellingProducts(1)
                .FirstOrDefault()
                .Price.Id, 50);

            foreach (var item in _productService.GetTopSellingProducts(5))
            {
                Console.WriteLine(item.Name, item.Price.Cost);
            }
        }
    }
}