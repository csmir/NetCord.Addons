using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.ChannelPinsUpdate"/> event.
    /// </summary>
    public abstract class ChannelPinsUpdateHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="ChannelPinsUpdateHandler"/> to handle the ChannelPinsUpdate event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected ChannelPinsUpdateHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(ChannelPinsUpdateEventArgs eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.ChannelPinsUpdate += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.ChannelPinsUpdate -= HandleAsync;
    }
}