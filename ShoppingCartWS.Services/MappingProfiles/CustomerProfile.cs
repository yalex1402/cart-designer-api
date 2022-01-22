using AutoMapper;
using ShoppingCartWS.Domain.Entities;
using ShoppingCartWS.Services.DtoModels;

namespace ShoppingCartWS.Services.MappingProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer,CustomerDto>();
            CreateMap<CustomerDto,Customer>();
            CreateMap<CustomerAddress,CustomerAddressDto>();
            CreateMap<CustomerAddressDto,CustomerAddress>();
        }
    }    
}