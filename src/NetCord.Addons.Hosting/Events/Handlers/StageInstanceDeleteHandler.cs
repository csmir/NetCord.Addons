using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.StageInstanceDelete"/> event.
    /// </summary>
    public abstract class StageInstanceDeleteHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="StageInstanceDeleteHandler"/> to handle the StageInstanceDelete event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected StageInstanceDeleteHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(StageInstance eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.StageInstanceDelete += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.StageInstanceDelete -= HandleAsync;
    }
}