using System.ComponentModel.DataAnnotations;

namespace ShoppingCartWS.BindingModels
{
    public class AddUserModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}