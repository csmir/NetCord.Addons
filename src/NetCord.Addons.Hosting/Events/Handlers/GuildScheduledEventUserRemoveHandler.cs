using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
   /// <summary>
   ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildScheduledEventUserRemove"/> event.
   /// </summary>
   public abstract class GuildScheduledEventUserRemoveHandler : GatewayEventHandler
   {
       /// <summary>
       ///     Creates a new <see cref="GuildScheduledEventUserRemoveHandler"/> to handle the GuildScheduledEventUserRemove event.
       /// </summary>
       /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
       protected GuildScheduledEventUserRemoveHandler(GatewayClient client) : base(client) { }
       
       /// <inheritdoc />
       public abstract ValueTask HandleAsync(GuildScheduledEventUserEventArgs eventArgs);
       
       /// <inheritdoc />
       public override void Subscribe()
           => Client.GuildScheduledEventUserRemove += HandleAsync;
       
       /// <inheritdoc />
       public override void UnSubscribe()
           => Client.GuildScheduledEventUserRemove -= HandleAsync;
   }
}