using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.LatencyUpdated"/> event.
    /// </summary>
    public abstract class LatencyUpdatedHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="LatencyUpdatedHandler"/> to handle the LatencyUpdated event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected LatencyUpdatedHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(TimeSpan eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.LatencyUpdated += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.LatencyUpdated -= HandleAsync;
    }
}