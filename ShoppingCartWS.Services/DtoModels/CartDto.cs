using System;
using System.Collections.Generic;

namespace ShoppingCartWS.Services.DtoModels
{
    public class CartDto
    {
        public Guid Id { get; set; }
        public List<CartItemDto> Items { get; set; }
        public double Total { get; set; }
    }
}