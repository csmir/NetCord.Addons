using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildBanAdd"/> event.
    /// </summary>
    public abstract class GuildBanAddHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="GuildBanAddHandler"/> to handle the GuildBanAdd event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected GuildBanAddHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(GuildBanEventArgs eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.GuildBanAdd += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.GuildBanAdd -= HandleAsync;
    }
}