using System;

namespace ShoppingCartWS.Domain.Entities
{
    public class Stock
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}