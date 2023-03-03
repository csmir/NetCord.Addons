using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.WebhooksUpdate"/> event.
    /// </summary>
    public abstract class WebhooksUpdateHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="WebhooksUpdateHandler"/> to handle the WebhooksUpdate event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected WebhooksUpdateHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(WebhooksUpdateEventArgs eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.WebhooksUpdate += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.WebhooksUpdate -= HandleAsync;
    }
}