using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildUserChunk"/> event.
    /// </summary>
    public abstract class GuildUserChunkHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="GuildUserChunkHandler"/> to handle the GuildUserChunk event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected GuildUserChunkHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(GuildUserChunkEventArgs eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.GuildUserChunk += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.GuildUserChunk -= HandleAsync;
    }
}