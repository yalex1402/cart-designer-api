using System;
using ShoppingCartWS.Domain.Repositories;

namespace ShoppingCartWS.Infrastructure.Data.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<ICustomerRepository> _lazyCustomerRepository;
        private readonly Lazy<IOrderRepository> _lazyOrderRepository;
        public RepositoryManager(DataContext dataContext)
        {
            _lazyCustomerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(dataContext));
            _lazyOrderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(dataContext));
        }
        public ICustomerRepository CustomerRepository => _lazyCustomerRepository.Value;
        public IOrderRepository OrderRepository => _lazyOrderRepository.Value;
    }
}