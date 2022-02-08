using System.ComponentModel.DataAnnotations;

namespace ShoppingCartWS.BindingModels
{
    public class AddUpdateRoleModel
    {
        [Required]
        public string Name { get; set; }
    }
}