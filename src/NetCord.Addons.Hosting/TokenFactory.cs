using Microsoft.Extensions.Options;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents a factory that can generate a token based on the received options.
    /// </summary>
    public class TokenFactory
    {
        private readonly string _token;

        public TokenFactory(IOptions<TokenConfigurationOptions> options)
        {
            _token = options.Value.Token;
        }

        /// <summary>
        ///     Gets a new <see cref="Token"/> from the available raw token.
        /// </summary>
        /// <param name="type">The token type to receive.</param>
        /// <returns>A new <see cref="Token"/> with available values.</returns>
        public Token GetToken(TokenType type = TokenType.Bot)
        {
            return new(type, _token);
        }
    }
}
