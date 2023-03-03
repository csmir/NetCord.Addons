using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildThreadUpdate"/> event.
    /// </summary>
    public abstract class GuildThreadUpdateHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="GuildThreadUpdateHandler"/> to handle the GuildThreadUpdate event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected GuildThreadUpdateHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(GuildThread eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.GuildThreadUpdate += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.GuildThreadUpdate -= HandleAsync;
    }
}