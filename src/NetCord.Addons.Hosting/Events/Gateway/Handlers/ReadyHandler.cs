using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.Ready"/> event.
    /// </summary>
    public abstract class ReadyHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="ReadyHandler"/> to handle the Ready event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected ReadyHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(ReadyEventArgs eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.Ready += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.Ready -= HandleAsync;
    }
}