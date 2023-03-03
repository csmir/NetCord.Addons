using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildChannelCreate"/> event.
    /// </summary>
    public abstract class GuildChannelCreateHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="GuildChannelCreateHandler"/> to handle the GuildChannelCreate event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected GuildChannelCreateHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(GuildChannelEventArgs eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.GuildChannelCreate += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.GuildChannelCreate -= HandleAsync;
    }
}