using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents a handler that is responsible for resolving inbound events.
    /// </summary>
    public abstract class GatewayEventHandler : IGatewayEventHandler
    {
        /// <inheritdoc />
        public GatewayClient Client { get; }

        /// <summary>
        ///     Creates a new <see cref="GatewayEventHandler"/> for the provided event type.
        /// </summary>
        /// <param name="client">The client used to subscribe and unsubscribe from the event.</param>
        public GatewayEventHandler(GatewayClient client)
            => Client = client;

        /// <inheritdoc />
        public abstract void Subscribe();

        /// <inheritdoc />
        public abstract void UnSubscribe();
    }
}
