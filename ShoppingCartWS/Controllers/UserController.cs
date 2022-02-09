using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartWS.BindingModels;
using ShoppingCartWS.Services.DtoModels;
using ShoppingCartWS.Services.ServicesContracts;

namespace ShoppingCartWS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IServicesManager _servicesManager;

        public UserController(IServicesManager servicesManager,
                            UserManager<IdentityUser> userManager,
                            SignInManager<IdentityUser> signInManager,
                            RoleManager<IdentityRole> roleManager) 
        {
            _servicesManager = servicesManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody]AddUserModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
                {
                    return BadRequest("Parameters are not valid");
                }
                IdentityUser userFound = await _userManager.FindByEmailAsync(model.Email);
                if (userFound != null)
                {
                    return BadRequest($"User {model.Email} already exists");
                }
                IdentityUser user = new IdentityUser()
                {
                    Email = model.Email,
                    UserName = model.Email,
                    PhoneNumber = model.PhoneNumber
                };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    return BadRequest($"User couldn't be created - error: {string.Join(",", result.Errors.Select(x => x.Description).ToArray())}");
                }
                return Ok($"User {model.Email} has been created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
            
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Parameters are not valid");
                }
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                if (result.Succeeded)
                {
                    IdentityUser userLoggedIn = await _userManager.FindByEmailAsync(model.Email);
                    UserLoginDto userDto = new UserLoginDto()
                    {
                        Email = userLoggedIn.Email, 
                        Id = userLoggedIn.Id
                    };
                    var token = _servicesManager.TokenFactoryService.GenerateToken(userDto);
                    return Ok(new 
                    {
                        Email = userLoggedIn.Email,
                        Token = token.TokenGenerated,
                        ExpiresIn = token.ExpiresIn
                    });
                }
                return BadRequest("Email or password are incorrect");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRoleAsync([FromBody]AssignRoleModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Parameters are not valid");
                }
                IdentityUser userFound = await _userManager.FindByEmailAsync(model.Email);
                if (userFound == null)
                {
                    return NotFound($"User {model.Email} does not exist");
                }
                IdentityRole roleFound = await _roleManager.FindByNameAsync(model.RoleName);
                if (roleFound == null)
                {
                    return NotFound($"Role {model.RoleName} not found");
                }
                IdentityResult resultRole = await _userManager.AddToRoleAsync(userFound, model.RoleName);
                if (!resultRole.Succeeded)
                {
                    return BadRequest($"Role could not be assigned to {userFound.UserName}- error: {string.Join(",", resultRole.Errors.Select(x => x.Description).ToArray())}");
                }
                return Ok($"User {userFound.Email} was assigned to {roleFound.Name} successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
    }
}