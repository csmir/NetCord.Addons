using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
