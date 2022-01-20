using System;
using System.Collections.Generic;

namespace ShoppingCartWS.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime DateGenerated { get; set; }
        public double Total { get; set; }
        public List<OrderDetail> Details { get; set; }
    }
}