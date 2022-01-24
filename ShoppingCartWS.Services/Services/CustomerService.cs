using System.Threading.Tasks;
using AutoMapper;
using ShoppingCartWS.Domain.Entities;
using ShoppingCartWS.Domain.Repositories;
using ShoppingCartWS.Services.DtoModels;
using ShoppingWS.Services.ServicesContracts;

namespace ShoppingWS.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository repository,
                                IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void CreateCustomer(CustomerDto customer)
        {
            Customer customerEntity = _mapper.Map<Customer>(customer);
            _repository.CreateCustomer(customerEntity);
        }

        public async Task CreateCustomerAsync(CustomerDto customer)
        {
            Customer customerEntity = _mapper.Map<Customer>(customer);
            await _repository.CreateCustomerAsync(customerEntity);
        }

        public void RemoveCustomer(CustomerDto customer)
        {
            Customer customerEntity = _mapper.Map<Customer>(customer);
            _repository.RemoveCustomerAsync(customerEntity);
        }

        public async Task RemoveCustomerAsync(CustomerDto customer)
        {
            Customer customerEntity = _mapper.Map<Customer>(customer);
            await _repository.RemoveCustomerAsync(customerEntity);
        }

        public void UpdateCustomer(CustomerDto customer)
        {
            Customer customerEntity = _mapper.Map<Customer>(customer);
            _repository.UpdateCustomerAsync(customerEntity);
        }

        public async Task UpdateCustomerAsync(CustomerDto customer)
        {
            Customer customerEntity = _mapper.Map<Customer>(customer);
            await _repository.UpdateCustomerAsync(customerEntity);
        }
    }
}