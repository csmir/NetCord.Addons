using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.StageInstanceCreate"/> event.
    /// </summary>
    public abstract class StageInstanceCreateHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="StageInstanceCreateHandler"/> to handle the StageInstanceCreate event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected StageInstanceCreateHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(StageInstance eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.StageInstanceCreate += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.StageInstanceCreate -= HandleAsync;
    }
}