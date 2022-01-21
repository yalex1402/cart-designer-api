using System.Threading.Tasks;
using ShoppingCartWS.Domain.Entities;

namespace ShoppingCartWS.Domain.Repositories
{
    public interface ICartRepository
    {
        void AddItemToCart(CartItem cartItem);
        Task AddItemToCartAsync(CartItem cartItem);
        void CleanCart(Cart cart);
        Task CleanCartAsync(Cart cart);
        void DeleteItemFromCart(CartItem cartItem);
        Task DeleteItemFromCartAsync(CartItem cartItem);
        void UpdateItemFromCart(CartItem cartItem);
        Task UpdateItemFromCartAsync(CartItem cartItem);
    }
}