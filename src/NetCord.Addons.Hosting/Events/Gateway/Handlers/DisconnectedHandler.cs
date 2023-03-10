using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.Disconnected"/> event.
    /// </summary>
    public abstract class DisconnectedHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="DisconnectedHandler"/> to handle the Disconnected event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected DisconnectedHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(Boolean eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.Disconnected += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.Disconnected -= HandleAsync;
    }
}