using System;
using AutoMapper;
using Microsoft.Extensions.Options;
using ShoppingCartWS.Domain.Repositories;
using ShoppingCartWS.Services.Configurations;
using ShoppingCartWS.Services.ServicesContracts;

namespace ShoppingCartWS.Services.Services
{
    public class ServicesManager : IServicesManager
    {
        private readonly Lazy<ICustomerService> _lazyCustomerService;
        private readonly Lazy<IOrderService> _lazyOrderService;
        private readonly Lazy<IJwtTokenFactoryService> _lazyTokenFactoryService;
        public ServicesManager(IRepositoryManager repository,
                                IMapper mapper,
                                IOptions<JwtConfig> jwtConfig)
        {
            _lazyCustomerService = new Lazy<ICustomerService>(()=> new CustomerService(repository, mapper));
            _lazyOrderService = new Lazy<IOrderService>(()=> new OrderService(repository, mapper));
            _lazyTokenFactoryService = new Lazy<IJwtTokenFactoryService>(()=> new JwtTokenFactoryService(jwtConfig));
        }
        public ICustomerService CustomerService => _lazyCustomerService.Value;
        public IOrderService OrderService => _lazyOrderService.Value;
        public IJwtTokenFactoryService TokenFactoryService => _lazyTokenFactoryService.Value;
    }
}