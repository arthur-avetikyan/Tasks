using AutoMapper;
using Store.DAL.Infrastructure;
using Store.DTO;
using Store.Entities;
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

        public ProductService(IUnitOfWork uunitOfWork, IMapper mapper)
        {
            _unitOfWork = uunitOfWork;
            _mapper = mapper;
        }

        public async Task AddProduct(ProductDTO product)
        {
            _unitOfWork.GetRepository<Product>().Insert(_mapper.Map<Product>(product));
            await _unitOfWork.SaveAsync();
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            return _mapper.Map<IEnumerable<ProductDTO>>(_unitOfWork.GetRepository<Product>().Get());
        }

        public IEnumerable<ProductDTO> GetTopSellingProducts(int count)
        {
            //to change
            return _mapper.Map<IEnumerable<ProductDTO>>(
                _unitOfWork.GetRepository<Product>().Get(null, o => o.OrderByDescending(p => p.Price.Cost), "Price").Take(count));
        }
    }
}
