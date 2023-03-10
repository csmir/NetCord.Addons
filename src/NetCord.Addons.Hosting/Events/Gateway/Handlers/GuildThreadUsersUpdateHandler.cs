using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildThreadUsersUpdate"/> event.
    /// </summary>
    public abstract class GuildThreadUsersUpdateHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="GuildThreadUsersUpdateHandler"/> to handle the GuildThreadUsersUpdate event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected GuildThreadUsersUpdateHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(GuildThreadUsersUpdateEventArgs eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.GuildThreadUsersUpdate += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.GuildThreadUsersUpdate -= HandleAsync;
    }
}