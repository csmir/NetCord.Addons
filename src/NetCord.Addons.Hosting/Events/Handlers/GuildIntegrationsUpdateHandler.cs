using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildIntegrationsUpdate"/> event.
    /// </summary>
    public abstract class GuildIntegrationsUpdateHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="GuildIntegrationsUpdateHandler"/> to handle the GuildIntegrationsUpdate event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected GuildIntegrationsUpdateHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(GuildIntegrationsUpdateEventArgs eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.GuildIntegrationsUpdate += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.GuildIntegrationsUpdate -= HandleAsync;
    }
}