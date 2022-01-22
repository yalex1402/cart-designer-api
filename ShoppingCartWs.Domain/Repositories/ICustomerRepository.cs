using System.Threading.Tasks;
using ShoppingCartWS.Domain.Entities;

namespace ShoppingCartWS.Domain.Repositories
{
    public interface ICustomerRepository
    {
        void CreateCustomer(Customer customer);
        Task CreateCustomerAsync(Customer customer);
        void UpdateCustomer(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        void RemoveCustomer(Customer customer);
        Task RemoveCustomerAsync(Customer customer);
    }
}