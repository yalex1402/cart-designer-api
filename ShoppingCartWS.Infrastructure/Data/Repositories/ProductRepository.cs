using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingCartWS.Domain.Entities;
using ShoppingCartWS.Domain.Repositories;
using ShoppingCartWS.Infrastructure.Data;

namespace ShoppingCartWS.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;

        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dataContext.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(string productId)
        {
            return await _dataContext.Products
                .Where(p => p.Id == productId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string productName)
        {
            return await _dataContext.Products
                .Where(p => p.Name.Contains(productName))
                .ToListAsync();
        }

        public void Insert(Product product)
        {
            _dataContext.Products.Add(product);
            _dataContext.SaveChanges();
        }

        public async Task InsertAsync(Product product)
        {
            _dataContext.Products.Add(product);
            await _dataContext.SaveChangesAsync();
        }

        public void Remove(Product product)
        {
            _dataContext.Products.Remove(product);
            _dataContext.SaveChanges();
        }

        public async Task RemoveAsync(Product product)
        {
            _dataContext.Products.Remove(product);
            await _dataContext.SaveChangesAsync();
        }
    }
}