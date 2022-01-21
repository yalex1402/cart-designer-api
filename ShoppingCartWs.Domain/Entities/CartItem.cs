using System;

namespace ShoppingCartWS.Domain.Entities
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public Guid CartId { get; set; }
        public double Total => Product.UnitSellingPrice * Quantity;
    }
}