using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.AutoModerationRuleCreate"/> event.
    /// </summary>
    public abstract class AutoModerationRuleCreateHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="AutoModerationRuleCreateHandler"/> to handle the AutoModerationRuleCreate event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected AutoModerationRuleCreateHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(AutoModerationRule eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.AutoModerationRuleCreate += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.AutoModerationRuleCreate -= HandleAsync;
    }
}