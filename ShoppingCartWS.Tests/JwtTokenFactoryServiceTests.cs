using Xunit;
using Moq;
using Microsoft.Extensions.Options;
using ShoppingCartWS.Services.Configurations;
using ShoppingCartWS.Services.Services;
using ShoppingCartWS.Services.DtoModels;

namespace ShoppingCartWS.Tests
{
    public class JwtTokenFactoryServiceTests
    {
        private readonly Mock<IOptions<JwtConfig>> jwtConfigStub;

        public JwtTokenFactoryServiceTests()
        {
            jwtConfigStub = new Mock<IOptions<JwtConfig>>();
        }

        [Fact]
        public void GenerateToken_WithInvalidParameters_ReturnsNull()
        {
            jwtConfigStub.Setup(config => config.Value).Returns(new JwtConfig()
            {
                SecretKey = "keyfortesting$asdjiucasdbcweuiqbbdsciubwiqbibdacbiasbdcubjasdbcabcdkdjsbc"
            });
            var service = new JwtTokenFactoryService(jwtConfigStub.Object);

            var result = service.GenerateToken(new UserLoginDto());

            Assert.Equal(null,result);
        }

        [Fact]
        public void GenerateToken_WithValidParameters_ReturnsTokenModel()
        {
            jwtConfigStub.Setup(config => config.Value).Returns(new JwtConfig()
            {
                SecretKey = "keyfortesting$asdjiucasdbcweuiqbbdsciubwiqbibdacbiasbdcubjasdbcabcdkdjsbc"
            });
            var service = new JwtTokenFactoryService(jwtConfigStub.Object);

            var result = service.GenerateToken(new UserLoginDto()
            {
                Email = "test@example.com",
                Id = "thisisatest"
            });

            Assert.IsType<TokenModel>(result);
        }
    }
}