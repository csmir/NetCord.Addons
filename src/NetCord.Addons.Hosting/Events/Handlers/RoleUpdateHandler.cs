using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
   /// <summary>
   ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.RoleUpdate"/> event.
   /// </summary>
   public abstract class RoleUpdateHandler : GatewayEventHandler
   {
       /// <summary>
       ///     Creates a new <see cref="RoleUpdateHandler"/> to handle the RoleUpdate event.
       /// </summary>
       /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
       protected RoleUpdateHandler(GatewayClient client) : base(client) { }
       
       /// <inheritdoc />
       public abstract ValueTask HandleAsync(RoleEventArgs eventArgs);
       
       /// <inheritdoc />
       public override void Subscribe()
           => Client.RoleUpdate += HandleAsync;
       
       /// <inheritdoc />
       public override void UnSubscribe()
           => Client.RoleUpdate -= HandleAsync;
   }
}