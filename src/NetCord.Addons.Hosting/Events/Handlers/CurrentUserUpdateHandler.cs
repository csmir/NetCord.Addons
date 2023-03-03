using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
   /// <summary>
   ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.CurrentUserUpdate"/> event.
   /// </summary>
   public abstract class CurrentUserUpdateHandler : GatewayEventHandler
   {
       /// <summary>
       ///     Creates a new <see cref="CurrentUserUpdateHandler"/> to handle the CurrentUserUpdate event.
       /// </summary>
       /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
       protected CurrentUserUpdateHandler(GatewayClient client) : base(client) { }
       
       /// <inheritdoc />
       public abstract ValueTask HandleAsync(SelfUser eventArgs);
       
       /// <inheritdoc />
       public override void Subscribe()
           => Client.CurrentUserUpdate += HandleAsync;
       
       /// <inheritdoc />
       public override void UnSubscribe()
           => Client.CurrentUserUpdate -= HandleAsync;
   }
}