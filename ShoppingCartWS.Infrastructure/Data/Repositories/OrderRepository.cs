using System.Threading.Tasks;
using ShoppingCartWS.Domain.Entities;
using ShoppingCartWS.Domain.Repositories;

namespace ShoppingCartWS.Infrastructure.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dataContext;

        public OrderRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddOrderAsync(Order order)
        {
            _dataContext.Orders.Add(order);
            await _dataContext.SaveChangesAsync();
        }

        public async Task CancelOrderAsync(Order order)
        {
            _dataContext.Orders.Remove(order);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            _dataContext.Orders.Update(order);
            await _dataContext.SaveChangesAsync();
        }
    }
}