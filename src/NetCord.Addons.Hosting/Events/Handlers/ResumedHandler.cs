using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
   /// <summary>
   ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.Resumed"/> event.
   /// </summary>
   public abstract class ResumedHandler : GatewayEventHandler
   {
       /// <summary>
       ///     Creates a new <see cref="ResumedHandler"/> to handle the Resumed event.
       /// </summary>
       /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
       protected ResumedHandler(GatewayClient client) : base(client) { }
       
       /// <inheritdoc />
       public abstract ValueTask HandleAsync();
       
       /// <inheritdoc />
       public override void Subscribe()
           => Client.Resumed += HandleAsync;
       
       /// <inheritdoc />
       public override void UnSubscribe()
           => Client.Resumed -= HandleAsync;
   }
}