using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildAuditLogEntryCreate"/> event.
    /// </summary>
    public abstract class GuildAuditLogEntryCreateHandler : GatewayEventHandler
    {
        /// <summary>
        ///     Creates a new <see cref="GuildAuditLogEntryCreateHandler"/> to handle the GuildAuditLogEntryCreate event.
        /// </summary>
        /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
        protected GuildAuditLogEntryCreateHandler(GatewayClient client) : base(client) { }

        /// <inheritdoc />
        public abstract ValueTask HandleAsync(AuditLogEntry eventArgs);

        /// <inheritdoc />
        public override void Subscribe()
            => Client.GuildAuditLogEntryCreate += HandleAsync;

        /// <inheritdoc />
        public override void UnSubscribe()
            => Client.GuildAuditLogEntryCreate -= HandleAsync;
    }
}