using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.MessageReactionAdd"/> event.
    /// </summary>
    public abstract class MessageReactionAddHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="MessageReactionAddHandler"/> to handle the MessageReactionAdd event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected MessageReactionAddHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(MessageReactionAddEventArgs eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.MessageReactionAdd += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.MessageReactionAdd -= HandleAsync;
    }
}