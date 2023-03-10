using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildThreadDelete"/> event.
    /// </summary>
    public abstract class GuildThreadDeleteHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="GuildThreadDeleteHandler"/> to handle the GuildThreadDelete event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected GuildThreadDeleteHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(GuildThreadDeleteEventArgs eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.GuildThreadDelete += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.GuildThreadDelete -= HandleAsync;
    }
}