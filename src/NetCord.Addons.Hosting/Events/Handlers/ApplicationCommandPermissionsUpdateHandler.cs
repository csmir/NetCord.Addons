using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
   /// <summary>
   ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.ApplicationCommandPermissionsUpdate"/> event.
   /// </summary>
   public abstract class ApplicationCommandPermissionsUpdateHandler : GatewayEventHandler
   {
       /// <summary>
       ///     Creates a new <see cref="ApplicationCommandPermissionsUpdateHandler"/> to handle the ApplicationCommandPermissionsUpdate event.
       /// </summary>
       /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
       protected ApplicationCommandPermissionsUpdateHandler(GatewayClient client) : base(client) { }
       
       /// <inheritdoc />
       public abstract ValueTask HandleAsync(ApplicationCommandPermission eventArgs);
       
       /// <inheritdoc />
       public override void Subscribe()
           => Client.ApplicationCommandPermissionsUpdate += HandleAsync;
       
       /// <inheritdoc />
       public override void UnSubscribe()
           => Client.ApplicationCommandPermissionsUpdate -= HandleAsync;
   }
}