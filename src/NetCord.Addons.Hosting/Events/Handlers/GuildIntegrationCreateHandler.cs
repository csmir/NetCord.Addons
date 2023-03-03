using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildIntegrationCreate"/> event.
    /// </summary>
    public abstract class GuildIntegrationCreateHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="GuildIntegrationCreateHandler"/> to handle the GuildIntegrationCreate event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected GuildIntegrationCreateHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(GuildIntegrationEventArgs eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.GuildIntegrationCreate += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.GuildIntegrationCreate -= HandleAsync;
    }
}