using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.MessageReactionRemove"/> event.
    /// </summary>
    public abstract class MessageReactionRemoveHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="MessageReactionRemoveHandler"/> to handle the MessageReactionRemove event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected MessageReactionRemoveHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(MessageReactionRemoveEventArgs eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.MessageReactionRemove += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.MessageReactionRemove -= HandleAsync;
    }
}