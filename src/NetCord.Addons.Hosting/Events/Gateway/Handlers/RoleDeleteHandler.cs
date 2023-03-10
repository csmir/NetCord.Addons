using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.RoleDelete"/> event.
    /// </summary>
    public abstract class RoleDeleteHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="RoleDeleteHandler"/> to handle the RoleDelete event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected RoleDeleteHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(RoleDeleteEventArgs eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.RoleDelete += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.RoleDelete -= HandleAsync;
    }
}