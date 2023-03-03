using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.MessageReactionRemoveEmoji"/> event.
    /// </summary>
    public abstract class MessageReactionRemoveEmojiHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="MessageReactionRemoveEmojiHandler"/> to handle the MessageReactionRemoveEmoji event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected MessageReactionRemoveEmojiHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(MessageReactionRemoveEmojiEventArgs eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.MessageReactionRemoveEmoji += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.MessageReactionRemoveEmoji -= HandleAsync;
    }
}