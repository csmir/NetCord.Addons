using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildIntegrationDelete"/> event.
    /// </summary>
    public abstract class GuildIntegrationDeleteHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="GuildIntegrationDeleteHandler"/> to handle the GuildIntegrationDelete event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected GuildIntegrationDeleteHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(GuildIntegrationDeleteEventArgs eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.GuildIntegrationDelete += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.GuildIntegrationDelete -= HandleAsync;
    }
}