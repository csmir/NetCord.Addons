using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
   /// <summary>
   ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildChannelUpdate"/> event.
   /// </summary>
   public abstract class GuildChannelUpdateHandler : GatewayEventHandler
   {
       /// <summary>
       ///     Creates a new <see cref="GuildChannelUpdateHandler"/> to handle the GuildChannelUpdate event.
       /// </summary>
       /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
       protected GuildChannelUpdateHandler(GatewayClient client) : base(client) { }
       
       /// <inheritdoc />
       public abstract ValueTask HandleAsync(GuildChannelEventArgs eventArgs);
       
       /// <inheritdoc />
       public override void Subscribe()
           => Client.GuildChannelUpdate += HandleAsync;
       
       /// <inheritdoc />
       public override void UnSubscribe()
           => Client.GuildChannelUpdate -= HandleAsync;
   }
}