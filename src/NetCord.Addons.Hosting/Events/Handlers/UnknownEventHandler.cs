using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
   /// <summary>
   ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.UnknownEvent"/> event.
   /// </summary>
   public abstract class UnknownEventHandler : GatewayEventHandler
   {
       /// <summary>
       ///     Creates a new <see cref="UnknownEventHandler"/> to handle the UnknownEvent event.
       /// </summary>
       /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
       protected UnknownEventHandler(GatewayClient client) : base(client) { }
       
       /// <inheritdoc />
       public abstract ValueTask HandleAsync(UnknownEventEventArgs eventArgs);
       
       /// <inheritdoc />
       public override void Subscribe()
           => Client.UnknownEvent += HandleAsync;
       
       /// <inheritdoc />
       public override void UnSubscribe()
           => Client.UnknownEvent -= HandleAsync;
   }
}