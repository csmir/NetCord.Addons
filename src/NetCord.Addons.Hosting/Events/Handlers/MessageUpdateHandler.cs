using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
   /// <summary>
   ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.MessageUpdate"/> event.
   /// </summary>
   public abstract class MessageUpdateHandler : GatewayEventHandler
   {
       /// <summary>
       ///     Creates a new <see cref="MessageUpdateHandler"/> to handle the MessageUpdate event.
       /// </summary>
       /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
       protected MessageUpdateHandler(GatewayClient client) : base(client) { }
       
       /// <inheritdoc />
       public abstract ValueTask HandleAsync(Message eventArgs);
       
       /// <inheritdoc />
       public override void Subscribe()
           => Client.MessageUpdate += HandleAsync;
       
       /// <inheritdoc />
       public override void UnSubscribe()
           => Client.MessageUpdate -= HandleAsync;
   }
}