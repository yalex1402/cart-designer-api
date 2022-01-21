using AutoMapper;
using ShoppingCartWS.Domain.Entities;
using ShoppingCartWS.Services.DtoModels;

namespace ShoppingCartWS.MappingProfiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<Cart,CartDto>();
            CreateMap<CartDto,Cart>();
            CreateMap<CartItemDto,CartItem>();
            CreateMap<CartItem,CartItemDto>();
        }
    }
}