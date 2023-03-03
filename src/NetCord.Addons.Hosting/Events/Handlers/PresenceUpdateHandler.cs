using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
   /// <summary>
   ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.PresenceUpdate"/> event.
   /// </summary>
   public abstract class PresenceUpdateHandler : GatewayEventHandler
   {
       /// <summary>
       ///     Creates a new <see cref="PresenceUpdateHandler"/> to handle the PresenceUpdate event.
       /// </summary>
       /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
       protected PresenceUpdateHandler(GatewayClient client) : base(client) { }
       
       /// <inheritdoc />
       public abstract ValueTask HandleAsync(Presence eventArgs);
       
       /// <inheritdoc />
       public override void Subscribe()
           => Client.PresenceUpdate += HandleAsync;
       
       /// <inheritdoc />
       public override void UnSubscribe()
           => Client.PresenceUpdate -= HandleAsync;
   }
}