using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
   /// <summary>
   ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildUserAdd"/> event.
   /// </summary>
   public abstract class GuildUserAddHandler : GatewayEventHandler
   {
       /// <summary>
       ///     Creates a new <see cref="GuildUserAddHandler"/> to handle the GuildUserAdd event.
       /// </summary>
       /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
       protected GuildUserAddHandler(GatewayClient client) : base(client) { }
       
       /// <inheritdoc />
       public abstract ValueTask HandleAsync(GuildUser eventArgs);
       
       /// <inheritdoc />
       public override void Subscribe()
           => Client.GuildUserAdd += HandleAsync;
       
       /// <inheritdoc />
       public override void UnSubscribe()
           => Client.GuildUserAdd -= HandleAsync;
   }
}