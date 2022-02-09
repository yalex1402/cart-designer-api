using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ShoppingCartWS.BindingModels;
using ShoppingCartWS.Controllers;
using Xunit;

namespace ShoppingCartWS.Tests
{
    public class RoleControllerTests
    {
        private readonly Mock<RoleManager<IdentityRole>> roleManagerStub;

        public RoleControllerTests()
        {
            roleManagerStub = new Mock<RoleManager<IdentityRole>>(Mock.Of<IRoleStore<IdentityRole>>(),null,null,null,null);
        }

        [Fact]
        public async Task CreateRoleAsync_WithInvalidParameters_ReturnsBadRequest()
        {
            var controller = new RoleController(roleManagerStub.Object);

            var result = await controller.CreateRoleAsync(new AddUpdateRoleModel());

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task CreateRoleAsync_WithErrorOnCreating_ReturnsBadRequest()
        {
            roleManagerStub.Setup(repo => repo.CreateAsync(It.IsAny<IdentityRole>()))
                .ReturnsAsync(new IdentityResult());
            var controller = new RoleController(roleManagerStub.Object);

            var result = await controller.CreateRoleAsync(new AddUpdateRoleModel()
            {
                Name = "roleTest"
            });

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task CreateRoleAsync_WithCorrectCreation_ReturnsOk()
        {
            roleManagerStub.Setup(repo => repo.CreateAsync(It.IsAny<IdentityRole>()))
                .ReturnsAsync(IdentityResult.Success);
            var controller = new RoleController(roleManagerStub.Object);

            var result = await controller.CreateRoleAsync(new AddUpdateRoleModel()
            {
                Name = "roleTest"
            });

            Assert.IsType<OkObjectResult>(result);
        }
    }
}