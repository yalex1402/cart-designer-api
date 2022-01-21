using AutoMapper;
using ShoppingCartWS.Domain.Entities;
using ShoppingCartWS.Services.DtoModels;

namespace ShoppingCartWS.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product,ProductDto>()
                    .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitSellingPrice));
            CreateMap<ProductDto,Product>()
                    .ForMember(dest => dest.UnitSellingPrice, opt => opt.MapFrom(src => src.UnitPrice));
        }
    }
}