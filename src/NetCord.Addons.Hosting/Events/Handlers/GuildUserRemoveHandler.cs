using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildUserRemove"/> event.
    /// </summary>
    public abstract class GuildUserRemoveHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="GuildUserRemoveHandler"/> to handle the GuildUserRemove event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected GuildUserRemoveHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(GuildUserRemoveEventArgs eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.GuildUserRemove += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.GuildUserRemove -= HandleAsync;
    }
}