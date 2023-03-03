using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
   /// <summary>
   ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildDelete"/> event.
   /// </summary>
   public abstract class GuildDeleteHandler : GatewayEventHandler
   {
       /// <summary>
       ///     Creates a new <see cref="GuildDeleteHandler"/> to handle the GuildDelete event.
       /// </summary>
       /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
       protected GuildDeleteHandler(GatewayClient client) : base(client) { }
       
       /// <inheritdoc />
       public abstract ValueTask HandleAsync(GuildDeleteEventArgs eventArgs);
       
       /// <inheritdoc />
       public override void Subscribe()
           => Client.GuildDelete += HandleAsync;
       
       /// <inheritdoc />
       public override void UnSubscribe()
           => Client.GuildDelete -= HandleAsync;
   }
}