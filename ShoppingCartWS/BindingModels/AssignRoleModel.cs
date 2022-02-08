using System.ComponentModel.DataAnnotations;

namespace ShoppingCartWS.BindingModels
{
    public class AssignRoleModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}