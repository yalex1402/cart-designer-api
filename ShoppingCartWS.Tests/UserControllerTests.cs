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
        private readonly Mock<IServicesManager> serviceManagerStub;
        private readonly Mock<UserManager<IdentityUser>> userManagerStub;
        private readonly Mock<SignInManager<IdentityUser>> signInManagerStub;
        private readonly Mock<RoleManager<IdentityRole>> roleManagerStub;

        public UserControllerTests()
        {
            serviceManagerStub = new Mock<IServicesManager>();
            userManagerStub = new Mock<UserManager<IdentityUser>>(Mock.Of<IUserStore<IdentityUser>>(), null, null, null, null, null, null, null, null);
            signInManagerStub = new Mock<SignInManager<IdentityUser>>(userManagerStub.Object,Mock.Of<IHttpContextAccessor>(), Mock.Of<IUserClaimsPrincipalFactory<IdentityUser>>(),null,null,null,null);
            roleManagerStub = new Mock<RoleManager<IdentityRole>>(Mock.Of<IRoleStore<IdentityRole>>(),null,null,null,null);
        }

        [Fact]
        public async Task RegisterUserAsync_WithInvalidParameters_ReturnsBadRequest()
        {
            var controller = new UserController(serviceManagerStub.Object,userManagerStub.Object,signInManagerStub.Object,roleManagerStub.Object);
            var result = await controller.RegisterUser(new AddUserModel());

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task RegisterUserAsync_WithExistingUser_ReturnsBadRequest()
        {
            userManagerStub.Setup(repo => repo.FindByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync(new IdentityUser());
            var controller = new UserController(serviceManagerStub.Object,userManagerStub.Object,signInManagerStub.Object,roleManagerStub.Object);

            var result = await controller.RegisterUser(new AddUserModel()
            {
                Email = "test@yopmail.com", 
                Password = "test"
            });

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task RegisterUserAsync_WithErrorOnCreating_ReturnsBadRequest()
        {
            userManagerStub.Setup(repo => repo.FindByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync((IdentityUser)null);
            userManagerStub.Setup(repo => repo.CreateAsync(It.IsAny<IdentityUser>(),It.IsAny<string>()))
                .ReturnsAsync(new IdentityResult());
            var controller = new UserController(serviceManagerStub.Object,userManagerStub.Object,signInManagerStub.Object,roleManagerStub.Object);

            var result = await controller.RegisterUser(new AddUserModel()
            {
                Email = "test@yopmail.com", 
                Password = "test"
            });

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task RegisterUserAsync_WithUnexistingUser_ReturnsOk()
        {
            userManagerStub.Setup(repo => repo.FindByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync((IdentityUser)null);
            userManagerStub.Setup(repo => repo.CreateAsync(It.IsAny<IdentityUser>(),It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);
            var controller = new UserController(serviceManagerStub.Object,userManagerStub.Object,signInManagerStub.Object,roleManagerStub.Object);

            var result = await controller.RegisterUser(new AddUserModel()
            {
                Email = "test@yopmail.com", 
                Password = "test"
            });

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task LoginAsync_WithInvalidParameters_ReturnsBadRequest()
        {
            var controller = new UserController(serviceManagerStub.Object,userManagerStub.Object,signInManagerStub.Object,roleManagerStub.Object);
            var result = await controller.LoginAsync(new LoginModel());

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task LoginAsync_WithIncorrectValues_ReturnsBadRequest()
        {
            signInManagerStub.Setup(repo => repo.PasswordSignInAsync(It.IsAny<string>(),It.IsAny<string>(),false,false)).ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Failed);
            var controller = new UserController(serviceManagerStub.Object,userManagerStub.Object,signInManagerStub.Object,roleManagerStub.Object);
            var result = await controller.LoginAsync(new LoginModel()
            {
                Email = "test@yopmail.com",
                Password = "incorrect",
            });

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task LoginAsync_WithCorrectValues_ReturnsOk()
        {
            serviceManagerStub.Setup(serv => serv.TokenFactoryService.GenerateToken(It.IsAny<UserLoginDto>())).Returns(new TokenModel(It.IsAny<string>(),It.IsAny<DateTime>()));
            userManagerStub.Setup(repo => repo.FindByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync(new IdentityUser());
            signInManagerStub.Setup(repo => repo.PasswordSignInAsync(It.IsAny<string>(),It.IsAny<string>(),false,false)).ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);
            var controller = new UserController(serviceManagerStub.Object,userManagerStub.Object,signInManagerStub.Object,roleManagerStub.Object);
            var result = await controller.LoginAsync(new LoginModel()
            {
                Email = "test@yopmail.com",
                Password = "test",
            });

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
