using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartWS.BindingModels;

namespace ShoppingCartWS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRoleAsync([FromBody]AddUpdateRoleModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                return BadRequest("Parameters are not valid");
            }
            IdentityRole role = new IdentityRole()
            {
                Name= model.Name
            };
            IdentityResult result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded)
            {
                return BadRequest($"Role couldn't be created - error: {string.Join(",", result.Errors.Select(x => x.Description).ToArray())}");
            }
            return Ok($"Role {model.Name} was created successfully");
        }
    }
}