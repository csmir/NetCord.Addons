using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.AutoModerationRuleDelete"/> event.
    /// </summary>
    public abstract class AutoModerationRuleDeleteHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="AutoModerationRuleDeleteHandler"/> to handle the AutoModerationRuleDelete event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected AutoModerationRuleDeleteHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(AutoModerationRule eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.AutoModerationRuleDelete += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.AutoModerationRuleDelete -= HandleAsync;
    }
}