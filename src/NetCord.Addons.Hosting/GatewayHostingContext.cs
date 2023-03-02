using NetCord.Gateway;
using NetCord.Gateway.WebSockets;
using NetCord.Rest;
using System.Diagnostics.CodeAnalysis;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents the context used to start a new <see cref="GatewayClient"/> with a hosted implementor.
    /// </summary>
    public class GatewayHostingContext
    {
        /// <summary>
        ///     The variable name to fetch tokens from.
        /// </summary>
        [DisallowNull]
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string? HostName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? LargeThreshold { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ShardProperties? Shard { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PresenceProperties? Presence { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ConnectionPropertiesProperties? ConnectionProperties { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IWebSocket? WebSocket { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisallowNull]
        public ApiVersion Version { get; set; } = ApiVersion.V10;

        /// <summary>
        /// 
        /// </summary>
        public RestClientConfiguration? RestClientConfiguration { get; set; }

        /// <summary>
        ///     The configuration used to configure the <see cref="GatewayClient"/>.
        /// </summary>
        [DisallowNull]
        public GatewayIntents Intents { get; set; } = GatewayIntents.AllNonPrivileged;
    }
}
