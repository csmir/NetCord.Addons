using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildUserUpdate"/> event.
    /// </summary>
    public abstract class GuildUserUpdateHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="GuildUserUpdateHandler"/> to handle the GuildUserUpdate event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected GuildUserUpdateHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(GuildUser eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.GuildUserUpdate += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.GuildUserUpdate -= HandleAsync;
    }
}