using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
   /// <summary>
   ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.Connecting"/> event.
   /// </summary>
   public abstract class ConnectingHandler : GatewayEventHandler
   {
       /// <summary>
       ///     Creates a new <see cref="ConnectingHandler"/> to handle the Connecting event.
       /// </summary>
       /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
       protected ConnectingHandler(GatewayClient client) : base(client) { }
       
       /// <inheritdoc />
       public abstract ValueTask HandleAsync();
       
       /// <inheritdoc />
       public override void Subscribe()
           => Client.Connecting += HandleAsync;
       
       /// <inheritdoc />
       public override void UnSubscribe()
           => Client.Connecting -= HandleAsync;
   }
}