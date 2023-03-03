using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
   /// <summary>
   ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.VoiceStateUpdate"/> event.
   /// </summary>
   public abstract class VoiceStateUpdateHandler : GatewayEventHandler
   {
       /// <summary>
       ///     Creates a new <see cref="VoiceStateUpdateHandler"/> to handle the VoiceStateUpdate event.
       /// </summary>
       /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
       protected VoiceStateUpdateHandler(GatewayClient client) : base(client) { }
       
       /// <inheritdoc />
       public abstract ValueTask HandleAsync(VoiceState eventArgs);
       
       /// <inheritdoc />
       public override void Subscribe()
           => Client.VoiceStateUpdate += HandleAsync;
       
       /// <inheritdoc />
       public override void UnSubscribe()
           => Client.VoiceStateUpdate -= HandleAsync;
   }
}