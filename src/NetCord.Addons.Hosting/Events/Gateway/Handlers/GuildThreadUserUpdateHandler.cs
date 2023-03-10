using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildThreadUserUpdate"/> event.
    /// </summary>
    public abstract class GuildThreadUserUpdateHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="GuildThreadUserUpdateHandler"/> to handle the GuildThreadUserUpdate event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected GuildThreadUserUpdateHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(GuildThreadUserUpdateEventArgs eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.GuildThreadUserUpdate += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.GuildThreadUserUpdate -= HandleAsync;
    }
}