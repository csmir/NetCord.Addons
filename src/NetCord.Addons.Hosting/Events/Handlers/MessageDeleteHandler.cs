using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.MessageDelete"/> event.
    /// </summary>
    public abstract class MessageDeleteHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="MessageDeleteHandler"/> to handle the MessageDelete event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected MessageDeleteHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(MessageDeleteEventArgs eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.MessageDelete += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.MessageDelete -= HandleAsync;
    }
}