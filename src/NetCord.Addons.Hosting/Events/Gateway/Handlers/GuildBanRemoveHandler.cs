using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildBanRemove"/> event.
    /// </summary>
    public abstract class GuildBanRemoveHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="GuildBanRemoveHandler"/> to handle the GuildBanRemove event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected GuildBanRemoveHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(GuildBanEventArgs eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.GuildBanRemove += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.GuildBanRemove -= HandleAsync;
    }
}