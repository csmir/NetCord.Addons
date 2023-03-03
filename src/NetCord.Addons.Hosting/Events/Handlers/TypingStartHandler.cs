using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
   /// <summary>
   ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.TypingStart"/> event.
   /// </summary>
   public abstract class TypingStartHandler : GatewayEventHandler
   {
       /// <summary>
       ///     Creates a new <see cref="TypingStartHandler"/> to handle the TypingStart event.
       /// </summary>
       /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
       protected TypingStartHandler(GatewayClient client) : base(client) { }
       
       /// <inheritdoc />
       public abstract ValueTask HandleAsync(TypingStartEventArgs eventArgs);
       
       /// <inheritdoc />
       public override void Subscribe()
           => Client.TypingStart += HandleAsync;
       
       /// <inheritdoc />
       public override void UnSubscribe()
           => Client.TypingStart -= HandleAsync;
   }
}