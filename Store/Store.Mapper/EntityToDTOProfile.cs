using AutoMapper;
using Store.DTO;
using Store.Entities.Models;

namespace Store.Mapper
{
    public class EntityToDTOProfile : Profile
    {
        public EntityToDTOProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Stock, StockDTO>().ReverseMap();
            CreateMap<ProductCategory, ProductCategoryDTO>().ReverseMap();
        }
    }
}
