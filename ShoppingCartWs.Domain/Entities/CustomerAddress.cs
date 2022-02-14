using System;

namespace ShoppingCartWS.Domain.Entities
{
    public class CustomerAddress
    {
        public string Id { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string AddressDetail { get; set; }
        public string CustomerId { get; set; }
    }
}