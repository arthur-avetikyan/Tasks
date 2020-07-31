using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.DAL.Infrastructure;
using Store.DTO;
using Store.Entities.Models;
using Store.IServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Services
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IRepository<Product> _productRepository;

        public ProductService(IUnitOfWork uunitOfWork, IMapper mapper)
        {
            _unitOfWork = uunitOfWork;
            _mapper = mapper;
            _productRepository = _unitOfWork.GetRepository<Product>();
        }

        public void AddProduct(ProductDTO product)
        {
            _productRepository.Insert(_mapper.Map<Product>(product));
            _unitOfWork.Save();
        }

        public async Task AddProducts(IEnumerable<ProductDTO> products)
        {
            await _productRepository.InsertRange(_mapper.Map<IEnumerable<Product>>(products));
            await _unitOfWork.SaveAsync();
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            return _mapper.Map<IEnumerable<ProductDTO>>(_productRepository.Get());
        }

        public IEnumerable<ProductInStockDTO> GetFilteredQueryable(int count)
        {
            var filtered = _productRepository
                .Query(w => w.Currency.ToUpper().Equals("AMD"), q => q.OrderBy(o => o.ProductName))
                .Where(w => w.Stock.InStock > 0)
                .OrderByDescending(o => o.Stock.InStock)
                .Take(count)
                .Select(s => new ProductInStockDTO { ProductName = s.ProductName, InStock = s.Stock.InStock });
            return filtered;
        }

        public IEnumerable<ProductInStockDTO> GetFilteredEnumarable(int count)
        {
            var filtered = _productRepository
                .Get(w => w.Currency.ToUpper().Equals("AMD"), q => q.OrderBy(o => o.ProductName), i => i.Stock)
                .Where(w => w.Stock.InStock > 0)
                .OrderByDescending(o => o.Stock.InStock)
                .Take(count)
                .Select(s => new ProductInStockDTO { ProductName = s.ProductName, InStock = s.Stock.InStock });
            return filtered;
        }
    }
}
