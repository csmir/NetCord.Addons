using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents a handler that is responsible for resolving inbound events.
    /// </summary>
    public interface IGatewayEventHandler
    {
        /// <summary>
        ///     The gateway client that should be used to subscribe and unsubscribe from events.
        /// </summary>
        public GatewayClient Client { get; }

        public void Subscribe();

        public void UnSubscribe();
    }
}
