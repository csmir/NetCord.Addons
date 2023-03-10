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

        /// <summary>
        ///     Subscribes the event to the implemented handling method.
        /// </summary>
        public void Subscribe();

        /// <summary>
        ///     Unsubscribes the event from the implemented handling method.
        /// </summary>
        public void UnSubscribe();
    }
}
