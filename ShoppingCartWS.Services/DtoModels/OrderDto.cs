using System;
using System.Collections.Generic;

namespace ShoppingCartWS.Services.DtoModels
{
    public class OrderDto
    {
        public string Id { get; set; }
        public DateTime DateGenerated { get; set; }
        public double Total { get; set; }
        public string Observations { get; set; }
        public string StatusProcess { get; set; }
        public bool IsPaid { get; set; }
        public List<OrderDetailDto> Details { get; set; }
    }
}