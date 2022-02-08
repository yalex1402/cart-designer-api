using System;

namespace ShoppingCartWS.Services.Configurations
{
    public class TokenModel
    {
        public TokenModel(string token, DateTime expiresIn)
        {
            TokenGenerated = token;
            ExpiresIn = expiresIn;
        }
        public string TokenGenerated { get; }       
        public DateTime ExpiresIn { get; }
    }
}