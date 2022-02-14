using System;
using System.Threading.Tasks;
using ShoppingCartWS.Domain.Entities;

namespace ShoppingCartWS.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerByIdAsync(string customerId);
        Task<Customer> GetCustomerByEmailAsync(string customerEmail);
        void CreateCustomer(Customer customer);
        Task CreateCustomerAsync(Customer customer);
        void UpdateCustomer(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        void RemoveCustomer(Customer customer);
        Task RemoveCustomerAsync(Customer customer);
    }
}