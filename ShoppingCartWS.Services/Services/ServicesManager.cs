using System;
using AutoMapper;
using ShoppingCartWS.Domain.Repositories;
using ShoppingCartWS.Services.ServicesContracts;

namespace ShoppingCartWS.Services.Services
{
    public class ServicesManager : IServicesManager
    {
        private readonly Lazy<ICustomerService> _lazyCustomerService;
        public ServicesManager(IRepositoryManager repository,
                                IMapper mapper)
        {
            _lazyCustomerService = new Lazy<ICustomerService>(()=> new CustomerService(repository, mapper));
        }
        public ICustomerService CustomerService => _lazyCustomerService.Value;
    }
}