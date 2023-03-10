using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.MessageReactionRemoveAll"/> event.
    /// </summary>
    public abstract class MessageReactionRemoveAllHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="MessageReactionRemoveAllHandler"/> to handle the MessageReactionRemoveAll event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected MessageReactionRemoveAllHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(MessageReactionRemoveAllEventArgs eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.MessageReactionRemoveAll += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.MessageReactionRemoveAll -= HandleAsync;
    }
}