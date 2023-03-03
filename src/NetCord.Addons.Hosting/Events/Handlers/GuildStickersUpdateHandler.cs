using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
   /// <summary>
   ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildStickersUpdate"/> event.
   /// </summary>
   public abstract class GuildStickersUpdateHandler : GatewayEventHandler
   {
       /// <summary>
       ///     Creates a new <see cref="GuildStickersUpdateHandler"/> to handle the GuildStickersUpdate event.
       /// </summary>
       /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
       protected GuildStickersUpdateHandler(GatewayClient client) : base(client) { }
       
       /// <inheritdoc />
       public abstract ValueTask HandleAsync(GuildStickersUpdateEventArgs eventArgs);
       
       /// <inheritdoc />
       public override void Subscribe()
           => Client.GuildStickersUpdate += HandleAsync;
       
       /// <inheritdoc />
       public override void UnSubscribe()
           => Client.GuildStickersUpdate -= HandleAsync;
   }
}