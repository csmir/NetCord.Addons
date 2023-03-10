using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildScheduledEventUpdate"/> event.
    /// </summary>
    public abstract class GuildScheduledEventUpdateHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="GuildScheduledEventUpdateHandler"/> to handle the GuildScheduledEventUpdate event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected GuildScheduledEventUpdateHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(GuildScheduledEvent eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.GuildScheduledEventUpdate += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.GuildScheduledEventUpdate -= HandleAsync;
    }
}