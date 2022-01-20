using System;

namespace ShoppingCartWS.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double UnitRealPrice { get; set; }
        public double UnitSellingPrice { get; set; }
        public Guid CategoryId { get; set; }
        public Guid StockId { get; set; }
    }
}