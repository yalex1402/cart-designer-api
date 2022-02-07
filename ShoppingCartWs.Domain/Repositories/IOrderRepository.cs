using System.Threading.Tasks;
using ShoppingCartWS.Domain.Entities;

namespace ShoppingCartWS.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task AddOrderAsync(Order order);
        Task CancelOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
    }
}
