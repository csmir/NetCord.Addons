using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
   /// <summary>
   ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.VoiceServerUpdate"/> event.
   /// </summary>
   public abstract class VoiceServerUpdateHandler : GatewayEventHandler
   {
       /// <summary>
       ///     Creates a new <see cref="VoiceServerUpdateHandler"/> to handle the VoiceServerUpdate event.
       /// </summary>
       /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
       protected VoiceServerUpdateHandler(GatewayClient client) : base(client) { }
       
       /// <inheritdoc />
       public abstract ValueTask HandleAsync(VoiceServerUpdateEventArgs eventArgs);
       
       /// <inheritdoc />
       public override void Subscribe()
           => Client.VoiceServerUpdate += HandleAsync;
       
       /// <inheritdoc />
       public override void UnSubscribe()
           => Client.VoiceServerUpdate -= HandleAsync;
   }
}