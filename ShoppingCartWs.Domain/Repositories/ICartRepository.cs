using ShoppingCartWS.Domain.Entities;

namespace ShoppingCartWS.Domain.Repositories
{
    public interface ICartRepository
    {
        void AddToCart(Product product);
        void CleanCart(Cart cart);
    }
}