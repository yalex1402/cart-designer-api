using System;

namespace ShoppingCartWS.Services.DtoModels
{
    public class ProductDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public bool Status { get; set; }
    }
}