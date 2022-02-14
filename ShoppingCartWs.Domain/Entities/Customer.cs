using System;
using System.Collections.Generic;

namespace ShoppingCartWS.Domain.Entities
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<CustomerAddress> Addresses { get; set; }
    }
}