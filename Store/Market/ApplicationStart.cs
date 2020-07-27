using Store.DAL.Infrastructure;
using Store.Entities;
using Store.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Market
{
    public class ApplicationStart
    {
        private IUnitOfWork _unitOfWork;
        private IProductService _productService;

        public ApplicationStart(IUnitOfWork unitOfWork, IProductService productService)
        {
            _unitOfWork = unitOfWork;
            _productService = productService;
        }

        public void Run()
        {
            _productService.Insert(new Product
            {
                Name = "Cabbage",
                Price = new Price
                {
                    Cost = 85,
                    Currency = "Amd",
                },
                Stock = new Stock
                {
                    InStock = 10
                }
            });
            _unitOfWork.Save();

            IEnumerable<string> lProducts = _productService.Get(product => product.Price.Cost > 80 && product.Stock.InStock > 0).Select(s => s.Name);

            foreach (string item in lProducts)
            {
                Console.WriteLine(item);
            }
        }
    }
}