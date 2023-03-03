using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
   /// <summary>
   ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.MessageDeleteBulk"/> event.
   /// </summary>
   public abstract class MessageDeleteBulkHandler : GatewayEventHandler
   {
       /// <summary>
       ///     Creates a new <see cref="MessageDeleteBulkHandler"/> to handle the MessageDeleteBulk event.
       /// </summary>
       /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
       protected MessageDeleteBulkHandler(GatewayClient client) : base(client) { }
       
       /// <inheritdoc />
       public abstract ValueTask HandleAsync(MessageDeleteBulkEventArgs eventArgs);
       
       /// <inheritdoc />
       public override void Subscribe()
           => Client.MessageDeleteBulk += HandleAsync;
       
       /// <inheritdoc />
       public override void UnSubscribe()
           => Client.MessageDeleteBulk -= HandleAsync;
   }
}