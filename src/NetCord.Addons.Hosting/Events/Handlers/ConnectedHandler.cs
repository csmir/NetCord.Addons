using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
   /// <summary>
   ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.Connected"/> event.
   /// </summary>
   public abstract class ConnectedHandler : GatewayEventHandler
   {
       /// <summary>
       ///     Creates a new <see cref="ConnectedHandler"/> to handle the Connected event.
       /// </summary>
       /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
       protected ConnectedHandler(GatewayClient client) : base(client) { }
       
       /// <inheritdoc />
       public abstract ValueTask HandleAsync();
       
       /// <inheritdoc />
       public override void Subscribe()
           => Client.Connected += HandleAsync;
       
       /// <inheritdoc />
       public override void UnSubscribe()
           => Client.Connected -= HandleAsync;
   }
}