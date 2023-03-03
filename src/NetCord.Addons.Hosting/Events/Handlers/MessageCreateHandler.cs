using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
   /// <summary>
   ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.MessageCreate"/> event.
   /// </summary>
   public abstract class MessageCreateHandler : GatewayEventHandler
   {
       /// <summary>
       ///     Creates a new <see cref="MessageCreateHandler"/> to handle the MessageCreate event.
       /// </summary>
       /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
       protected MessageCreateHandler(GatewayClient client) : base(client) { }
       
       /// <inheritdoc />
       public abstract ValueTask HandleAsync(Message eventArgs);
       
       /// <inheritdoc />
       public override void Subscribe()
           => Client.MessageCreate += HandleAsync;
       
       /// <inheritdoc />
       public override void UnSubscribe()
           => Client.MessageCreate -= HandleAsync;
   }
}