using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
   /// <summary>
   ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildInviteCreate"/> event.
   /// </summary>
   public abstract class GuildInviteCreateHandler : GatewayEventHandler
   {
       /// <summary>
       ///     Creates a new <see cref="GuildInviteCreateHandler"/> to handle the GuildInviteCreate event.
       /// </summary>
       /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
       protected GuildInviteCreateHandler(GatewayClient client) : base(client) { }
       
       /// <inheritdoc />
       public abstract ValueTask HandleAsync(GuildInvite eventArgs);
       
       /// <inheritdoc />
       public override void Subscribe()
           => Client.GuildInviteCreate += HandleAsync;
       
       /// <inheritdoc />
       public override void UnSubscribe()
           => Client.GuildInviteCreate -= HandleAsync;
   }
}