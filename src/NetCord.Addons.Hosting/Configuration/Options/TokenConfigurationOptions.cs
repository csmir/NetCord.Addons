namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents configuration bound options that assist in resolving the token in the <see cref="TokenFactory"/>.
    /// </summary>
    public class TokenConfigurationOptions
    {
        /// <summary>
        ///     The raw token received through the <see cref="GatewayHostingContext"/>.
        /// </summary>
        public string Token { get; set; } = string.Empty;
    }
}
