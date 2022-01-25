using System;
using ShoppingCartWS.Domain.Repositories;

namespace ShoppingCartWS.Infrastructure.Data.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<ICustomerRepository> _lazyCustomerRepository;
        public RepositoryManager(DataContext dataContext)
        {
            _lazyCustomerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(dataContext));
        }
        public ICustomerRepository CustomerRepository => _lazyCustomerRepository.Value;
    }
}