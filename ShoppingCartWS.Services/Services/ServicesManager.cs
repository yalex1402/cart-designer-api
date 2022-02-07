using System;
using AutoMapper;
using ShoppingCartWS.Domain.Repositories;
using ShoppingCartWS.Services.ServicesContracts;

namespace ShoppingCartWS.Services.Services
{
    public class ServicesManager : IServicesManager
    {
        private readonly Lazy<ICustomerService> _lazyCustomerService;
        private readonly Lazy<IOrderService> _lazyOrderService;
        public ServicesManager(IRepositoryManager repository,
                                IMapper mapper)
        {
            _lazyCustomerService = new Lazy<ICustomerService>(()=> new CustomerService(repository, mapper));
            _lazyOrderService = new Lazy<IOrderService>(()=> new OrderService(repository, mapper));
        }
        public ICustomerService CustomerService => _lazyCustomerService.Value;
        public IOrderService OrderService => _lazyOrderService.Value;
    }
}