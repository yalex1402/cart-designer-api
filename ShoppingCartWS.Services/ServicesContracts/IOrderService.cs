using System.Threading.Tasks;
using ShoppingCartWS.Services.DtoModels;

namespace ShoppingCartWS.Services.ServicesContracts
{
    public interface IOrderService
    {
        Task AddOrderAsync(OrderDto order);
        Task CancelOrderAsync(OrderDto order);
        Task UpdateOrderAsync(OrderDto order);
    }
}