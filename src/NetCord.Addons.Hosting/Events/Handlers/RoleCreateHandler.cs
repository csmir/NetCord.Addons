using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.RoleCreate"/> event.
    /// </summary>
    public abstract class RoleCreateHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="RoleCreateHandler"/> to handle the RoleCreate event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected RoleCreateHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(RoleEventArgs eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.RoleCreate += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.RoleCreate -= HandleAsync;
    }
}