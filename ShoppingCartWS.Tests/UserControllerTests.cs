using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ShoppingCartWS.BindingModels;
using ShoppingCartWS.Controllers;
using ShoppingCartWS.Services.Configurations;
using ShoppingCartWS.Services.DtoModels;
using ShoppingCartWS.Services.ServicesContracts;
using Xunit;

namespace ShoppingCartWS.Tests
{
    public class UserControllerTests
    {
        [Fact]
        public async Task RegisterUserAsync_WithExistingUser_ReturnsBadRequest()
        {
            var serviceManagerStub = new Mock<IServicesManager>();
            var userManagerStub = new Mock<UserManager<IdentityUser>>(Mock.Of<IUserStore<IdentityUser>>(), null, null, null, null, null, null, null, null);
            var signInManagerStub = new Mock<SignInManager<IdentityUser>>(userManagerStub.Object,Mock.Of<IHttpContextAccessor>(), Mock.Of<IUserClaimsPrincipalFactory<IdentityUser>>(),null,null,null,null);
            var roleManagerStub = new Mock<RoleManager<IdentityRole>>(Mock.Of<IRoleStore<IdentityRole>>(),null,null,null,null);
            userManagerStub.Setup(repo => repo.FindByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync(new IdentityUser());
            var controller = new UserController(serviceManagerStub.Object,userManagerStub.Object,signInManagerStub.Object,roleManagerStub.Object);

            var result = await controller.RegisterUser(new AddUserModel());

            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
