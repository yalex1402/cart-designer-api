using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingCartWS.Domain.Entities;

namespace ShoppingCartWS.Domain.Repositories
{
    public interface IProductRepository
    {
        void Insert(Product product);
        Task InsertAsync(Product product);
        void Remove(Product product);
        Task RemoveAsync(Product product);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetProduct(string productId);
        Task<IEnumerable<Product>> GetProductByName(string productName);
    }
}