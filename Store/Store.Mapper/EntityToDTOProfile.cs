using AutoMapper;
using Store.DTO;
using Store.Entities;

namespace Store.Mapper
{
    public class EntityToDTOProfile : Profile
    {
        public EntityToDTOProfile()
        {
            CreateMap<Price, PriceDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Stock, StockDTO>().ReverseMap();
        }
    }
}
