using Microsoft.Extensions.Options;

namespace NetCord.Addons.Hosting
{
    public class TokenFactory
    {
        private readonly string _token;

        public TokenFactory(IOptions<GatewayConfigurationOptions> options)
        {
            _token = options.Value.Token;
        }

        public Token GetToken(TokenType type = TokenType.Bot)
        {
            return new(type, _token);
        }
    }
}
