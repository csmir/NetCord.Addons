using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.AutoModerationActionExecution"/> event.
    /// </summary>
    public abstract class AutoModerationActionExecutionHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="AutoModerationActionExecutionHandler"/> to handle the AutoModerationActionExecution event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected AutoModerationActionExecutionHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(AutoModerationActionExecutionEventArgs eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.AutoModerationActionExecution += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.AutoModerationActionExecution -= HandleAsync;
    }
}