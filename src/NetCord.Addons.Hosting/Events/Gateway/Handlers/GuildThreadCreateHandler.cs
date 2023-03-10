using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildThreadCreate"/> event.
    /// </summary>
    public abstract class GuildThreadCreateHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="GuildThreadCreateHandler"/> to handle the GuildThreadCreate event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected GuildThreadCreateHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(GuildThreadCreateEventArgs eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.GuildThreadCreate += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.GuildThreadCreate -= HandleAsync;
    }
}