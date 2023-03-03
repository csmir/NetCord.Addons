using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
   /// <summary>
   ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildUpdate"/> event.
   /// </summary>
   public abstract class GuildUpdateHandler : GatewayEventHandler
   {
       /// <summary>
       ///     Creates a new <see cref="GuildUpdateHandler"/> to handle the GuildUpdate event.
       /// </summary>
       /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
       protected GuildUpdateHandler(GatewayClient client) : base(client) { }
       
       /// <inheritdoc />
       public abstract ValueTask HandleAsync(Guild eventArgs);
       
       /// <inheritdoc />
       public override void Subscribe()
           => Client.GuildUpdate += HandleAsync;
       
       /// <inheritdoc />
       public override void UnSubscribe()
           => Client.GuildUpdate -= HandleAsync;
   }
}