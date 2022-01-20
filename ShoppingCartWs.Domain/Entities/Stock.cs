using System;

namespace ShoppingCartWS.Domain.Entities
{
    public class Stock
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}