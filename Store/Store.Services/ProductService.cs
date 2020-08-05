using AutoMapper;
using Store.DAL.Infrastructure;
using Store.DTO;
using Store.Entities.Models;
using Store.IServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using IMapper = AutoMapper.IMapper;
using IMyMapper = Store.IServices.IMapper;

namespace Store.Services
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IMyMapper _myMapper;
        private IRepository<Product> _productRepository;
        private IRepository<ProductCategory> _productCategoryRepository;

        public ProductService(IUnitOfWork uunitOfWork, IMapper mapper, IMyMapper myMapper)
        {
            _unitOfWork = uunitOfWork;
            _mapper = mapper;
            _myMapper = myMapper;
            _productRepository = _unitOfWork.GetRepository<Product>();
            _productCategoryRepository = _unitOfWork.GetRepository<ProductCategory>();
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
                .Get(filter: w => w.Currency.ToUpper().Equals("AMD")
                           && w.Stock.InStock > 0,
                     orderBy: q => q.OrderBy(o => o.ProductName).ThenBy(t => t.Stock.InStock),
                     take: count,
                     includes: i => i.Stock)
                .Select(s => new ProductInStockDTO { ProductName = s.ProductName, InStock = s.Stock.InStock });
            return filtered;
        }

        public ProductCategoryDTO GetProductsInCategory()
        {
            ProductCategory productCategory = _productCategoryRepository.Get(includes: i => i.Products)
                                                .FirstOrDefault();

            ProductCategoryDTO mapped = _myMapper.MapTo<ProductCategoryDTO, ProductCategory>(productCategory);

            return mapped;
        }
    }
}
