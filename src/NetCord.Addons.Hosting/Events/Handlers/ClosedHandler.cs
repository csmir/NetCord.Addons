using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.Closed"/> event.
    /// </summary>
    public abstract class ClosedHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="ClosedHandler"/> to handle the Closed event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected ClosedHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync();

        /// <inheritdoc />
        public override void Subscribe()
            => Client.Closed += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.Closed -= HandleAsync;
    }
}