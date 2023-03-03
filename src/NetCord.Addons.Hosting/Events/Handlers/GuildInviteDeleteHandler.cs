using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildInviteDelete"/> event.
    /// </summary>
    public abstract class GuildInviteDeleteHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="GuildInviteDeleteHandler"/> to handle the GuildInviteDelete event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected GuildInviteDeleteHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(GuildInviteDeleteEventArgs eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.GuildInviteDelete += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.GuildInviteDelete -= HandleAsync;
    }
}