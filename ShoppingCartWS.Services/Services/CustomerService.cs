using System.Threading.Tasks;
using AutoMapper;
using ShoppingCartWS.Domain.Entities;
using ShoppingCartWS.Domain.Repositories;
using ShoppingCartWS.Services.DtoModels;
using ShoppingCartWS.Services.ServicesContracts;

namespace ShoppingCartWS.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public CustomerService(IRepositoryManager repository,
                                IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void CreateCustomer(CustomerDto customer)
        {
            Customer customerEntity = _mapper.Map<Customer>(customer);
            _repository.CustomerRepository.CreateCustomer(customerEntity);
        }

        public async Task CreateCustomerAsync(CustomerDto customer)
        {
            Customer customerEntity = _mapper.Map<Customer>(customer);
            await _repository.CustomerRepository.CreateCustomerAsync(customerEntity);
        }

        public void RemoveCustomer(CustomerDto customer)
        {
            Customer customerEntity = _mapper.Map<Customer>(customer);
            _repository.CustomerRepository.RemoveCustomerAsync(customerEntity);
        }

        public async Task RemoveCustomerAsync(CustomerDto customer)
        {
            Customer customerEntity = _mapper.Map<Customer>(customer);
            await _repository.CustomerRepository.RemoveCustomerAsync(customerEntity);
        }

        public void UpdateCustomer(CustomerDto customer)
        {
            Customer customerEntity = _mapper.Map<Customer>(customer);
            _repository.CustomerRepository.UpdateCustomerAsync(customerEntity);
        }

        public async Task UpdateCustomerAsync(CustomerDto customer)
        {
            Customer customerEntity = _mapper.Map<Customer>(customer);
            await _repository.CustomerRepository.UpdateCustomerAsync(customerEntity);
        }
    }
}