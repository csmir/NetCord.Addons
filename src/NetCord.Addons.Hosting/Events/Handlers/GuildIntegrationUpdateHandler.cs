using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
   /// <summary>
   ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildIntegrationUpdate"/> event.
   /// </summary>
   public abstract class GuildIntegrationUpdateHandler : GatewayEventHandler
   {
       /// <summary>
       ///     Creates a new <see cref="GuildIntegrationUpdateHandler"/> to handle the GuildIntegrationUpdate event.
       /// </summary>
       /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
       protected GuildIntegrationUpdateHandler(GatewayClient client) : base(client) { }
       
       /// <inheritdoc />
       public abstract ValueTask HandleAsync(GuildIntegrationEventArgs eventArgs);
       
       /// <inheritdoc />
       public override void Subscribe()
           => Client.GuildIntegrationUpdate += HandleAsync;
       
       /// <inheritdoc />
       public override void UnSubscribe()
           => Client.GuildIntegrationUpdate -= HandleAsync;
   }
}