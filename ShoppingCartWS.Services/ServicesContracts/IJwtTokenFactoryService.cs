using ShoppingCartWS.Services.Configurations;
using ShoppingCartWS.Services.DtoModels;

namespace ShoppingCartWS.Services.ServicesContracts
{
    public interface IJwtTokenFactoryService
    {
        TokenModel GenerateToken(UserLoginDto user);
    }
}