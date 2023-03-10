using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.Log"/> event.
    /// </summary>
    public abstract class LogHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="LogHandler"/> to handle the Log event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected LogHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(LogMessage eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.Log += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.Log -= HandleAsync;
    }
}