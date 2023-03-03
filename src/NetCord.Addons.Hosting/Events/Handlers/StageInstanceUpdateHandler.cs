using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
   /// <summary>
   ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.StageInstanceUpdate"/> event.
   /// </summary>
   public abstract class StageInstanceUpdateHandler : GatewayEventHandler
   {
       /// <summary>
       ///     Creates a new <see cref="StageInstanceUpdateHandler"/> to handle the StageInstanceUpdate event.
       /// </summary>
       /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
       protected StageInstanceUpdateHandler(GatewayClient client) : base(client) { }
       
       /// <inheritdoc />
       public abstract ValueTask HandleAsync(StageInstance eventArgs);
       
       /// <inheritdoc />
       public override void Subscribe()
           => Client.StageInstanceUpdate += HandleAsync;
       
       /// <inheritdoc />
       public override void UnSubscribe()
           => Client.StageInstanceUpdate -= HandleAsync;
   }
}