using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShoppingCartWS.Services.Configurations;
using ShoppingCartWS.Services.DtoModels;
using ShoppingCartWS.Services.ServicesContracts;

namespace ShoppingCartWS.Services.Services
{
    public class JwtTokenFactoryService : IJwtTokenFactoryService
    {
        private readonly JwtConfig _tokenConfig;

        public JwtTokenFactoryService(IOptions<JwtConfig> jwtConfig)
        {
            _tokenConfig = jwtConfig.Value;
        }

        public TokenModel GenerateToken(UserLoginDto user)
        {
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Id))
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenConfig.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.NameId,user.Id),
                    new Claim(JwtRegisteredClaimNames.Email,user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenCreated = tokenHandler.CreateToken(tokenDescriptor);
            var result = new {
                token = tokenHandler.WriteToken(tokenCreated),
                expiration = tokenCreated.ValidTo.ToLocalTime()
            };
            return new TokenModel(result.token,result.expiration);
        }
    }
}