using System;

namespace ShoppingCartWS.Domain.Entities
{
    public class CartDetail
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
    }
}