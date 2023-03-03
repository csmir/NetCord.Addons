using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
   /// <summary>
   ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildScheduledEventDelete"/> event.
   /// </summary>
   public abstract class GuildScheduledEventDeleteHandler : GatewayEventHandler
   {
       /// <summary>
       ///     Creates a new <see cref="GuildScheduledEventDeleteHandler"/> to handle the GuildScheduledEventDelete event.
       /// </summary>
       /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
       protected GuildScheduledEventDeleteHandler(GatewayClient client) : base(client) { }
       
       /// <inheritdoc />
       public abstract ValueTask HandleAsync(GuildScheduledEvent eventArgs);
       
       /// <inheritdoc />
       public override void Subscribe()
           => Client.GuildScheduledEventDelete += HandleAsync;
       
       /// <inheritdoc />
       public override void UnSubscribe()
           => Client.GuildScheduledEventDelete -= HandleAsync;
   }
}