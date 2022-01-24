using System.Threading.Tasks;
using ShoppingCartWS.Services.DtoModels;

namespace ShoppingWS.Services.ServicesContracts
{
    public interface ICustomerService
    {
        void CreateCustomer(CustomerDto customer);
        Task CreateCustomerAsync(CustomerDto customer);
        void UpdateCustomer(CustomerDto customer);
        Task UpdateCustomerAsync(CustomerDto customer);
        void RemoveCustomer(CustomerDto customer);
        Task RemoveCustomerAsync(CustomerDto customer);
    }
}