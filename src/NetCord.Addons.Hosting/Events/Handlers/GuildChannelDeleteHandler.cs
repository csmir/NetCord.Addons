using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildChannelDelete"/> event.
    /// </summary>
    public abstract class GuildChannelDeleteHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="GuildChannelDeleteHandler"/> to handle the GuildChannelDelete event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected GuildChannelDeleteHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(GuildChannelEventArgs eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.GuildChannelDelete += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.GuildChannelDelete -= HandleAsync;
    }
}