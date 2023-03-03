using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
   /// <summary>
   ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildEmojisUpdate"/> event.
   /// </summary>
   public abstract class GuildEmojisUpdateHandler : GatewayEventHandler
   {
       /// <summary>
       ///     Creates a new <see cref="GuildEmojisUpdateHandler"/> to handle the GuildEmojisUpdate event.
       /// </summary>
       /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
       protected GuildEmojisUpdateHandler(GatewayClient client) : base(client) { }
       
       /// <inheritdoc />
       public abstract ValueTask HandleAsync(GuildEmojisUpdateEventArgs eventArgs);
       
       /// <inheritdoc />
       public override void Subscribe()
           => Client.GuildEmojisUpdate += HandleAsync;
       
       /// <inheritdoc />
       public override void UnSubscribe()
           => Client.GuildEmojisUpdate -= HandleAsync;
   }
}