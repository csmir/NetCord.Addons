using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildScheduledEventUserAdd"/> event.
    /// </summary>
    public abstract class GuildScheduledEventUserAddHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="GuildScheduledEventUserAddHandler"/> to handle the GuildScheduledEventUserAdd event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected GuildScheduledEventUserAddHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(GuildScheduledEventUserEventArgs eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.GuildScheduledEventUserAdd += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.GuildScheduledEventUserAdd -= HandleAsync;
    }
}