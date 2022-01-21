using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartWS.Domain.Entities
{
    public class Cart
    {
        public Guid Id { get; set; }
        public double Total => Items.Sum(cd => cd.Total);
        public List<CartItem> Items { get; set; }
    }
}