using System;
using System.Collections.Generic;

namespace ShoppingCartWS.Domain.Entities
{
    public class Cart
    {
        public Guid Id { get; set; }
        public double Total { get; set; }
        public List<CartDetail> Details { get; set; }
    }
}