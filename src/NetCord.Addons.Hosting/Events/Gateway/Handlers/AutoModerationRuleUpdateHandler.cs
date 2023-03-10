using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.AutoModerationRuleUpdate"/> event.
    /// </summary>
    public abstract class AutoModerationRuleUpdateHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="AutoModerationRuleUpdateHandler"/> to handle the AutoModerationRuleUpdate event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected AutoModerationRuleUpdateHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(AutoModerationRule eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.AutoModerationRuleUpdate += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.AutoModerationRuleUpdate -= HandleAsync;
    }
}