using System;

namespace ShoppingCartWS.Domain.Entities
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double UnitRealPrice { get; set; }
        public double UnitSellingPrice { get; set; }
        public bool Status { get; set; }
        public string CategoryId { get; set; }
        public string StockId { get; set; }
    }
}