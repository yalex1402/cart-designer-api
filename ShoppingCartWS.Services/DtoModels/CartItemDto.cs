using System;

namespace ShoppingCartWS.Services.DtoModels
{
    public class CartItemDto
    {
        public Guid Id { get; set; }
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
    }
}