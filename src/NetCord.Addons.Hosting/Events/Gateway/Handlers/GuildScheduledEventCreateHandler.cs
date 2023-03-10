using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildScheduledEventCreate"/> event.
    /// </summary>
    public abstract class GuildScheduledEventCreateHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="GuildScheduledEventCreateHandler"/> to handle the GuildScheduledEventCreate event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected GuildScheduledEventCreateHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(GuildScheduledEvent eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.GuildScheduledEventCreate += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.GuildScheduledEventCreate -= HandleAsync;
    }
}