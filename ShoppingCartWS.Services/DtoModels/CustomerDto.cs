using System;
using System.Collections.Generic;

namespace ShoppingCartWS.Services.DtoModels
{
    public class CustomerDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<CustomerAddressDto> Addresses { get; set; }
    }
}