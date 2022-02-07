using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartWS.BindingModels;
using ShoppingCartWS.Services.ServicesContracts;

namespace ShoppingCartWS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IServicesManager _servicesManager;

        public UserController(IServicesManager servicesManager,
                            UserManager<IdentityUser> userManager,
                            SignInManager<IdentityUser> signInManager) 
        {
            _servicesManager = servicesManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody]AddUserModel model)
        {
            IdentityUser user = new IdentityUser()
            {
                Email = model.Email,
                UserName = model.UserName,
                PhoneNumber = model.PhoneNumber
            };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return BadRequest($"User couldn't be created - error: {string.Join(",", result.Errors.Select(x => x.Description).ToArray())}");
            }
            return Ok($"User {model.UserName} has been created successfully");
        }
    }
}