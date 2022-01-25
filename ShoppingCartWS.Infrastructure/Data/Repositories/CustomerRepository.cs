using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingCartWS.Domain.Entities;
using ShoppingCartWS.Domain.Repositories;

namespace ShoppingCartWS.Infrastructure.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _dataContext;

        public CustomerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid customerId)
        {
            return await _dataContext.Customers.Where(c => c.Id == customerId).FirstOrDefaultAsync();
        }

        public async Task<Customer> GetCustomerByEmailAsync(string customerEmail)
        {
            return await _dataContext.Customers.Where(c => c.Email == customerEmail).FirstOrDefaultAsync();
        }

        public void CreateCustomer(Customer customer)
        {
            _dataContext.Customers.Add(customer);
            _dataContext.SaveChanges();
        }

        public async Task CreateCustomerAsync(Customer customer)
        {
            _dataContext.Customers.Add(customer);
            await _dataContext.SaveChangesAsync();
        }

        public void RemoveCustomer(Customer customer)
        {
            _dataContext.Customers.Remove(customer);
            _dataContext.SaveChanges();
        }

        public async Task RemoveCustomerAsync(Customer customer)
        {
            _dataContext.Customers.Remove(customer);
            await _dataContext.SaveChangesAsync();
        }

        public void UpdateCustomer(Customer customer)
        {
            _dataContext.Customers.Update(customer);
            _dataContext.SaveChanges();
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            _dataContext.Customers.Update(customer);
            await _dataContext.SaveChangesAsync();
        }
    }
}