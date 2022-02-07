using System;

namespace ShoppingCartWS.Services.DtoModels
{
    public class OrderDetailDto
    {
        public Guid Id { get; set; }
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
        public string Observations { get; set; }
        public double Total { get; set; }
    }
}