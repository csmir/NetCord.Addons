using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.InteractionCreate"/> event.
    /// </summary>
    public abstract class InteractionCreateHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="InteractionCreateHandler"/> to handle the InteractionCreate event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected InteractionCreateHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(Interaction eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.InteractionCreate += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.InteractionCreate -= HandleAsync;
    }
}