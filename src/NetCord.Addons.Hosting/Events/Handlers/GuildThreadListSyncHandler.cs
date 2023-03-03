using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
   /// <summary>
   ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.GuildThreadListSync"/> event.
   /// </summary>
   public abstract class GuildThreadListSyncHandler : GatewayEventHandler
   {
       /// <summary>
       ///     Creates a new <see cref="GuildThreadListSyncHandler"/> to handle the GuildThreadListSync event.
       /// </summary>
       /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
       protected GuildThreadListSyncHandler(GatewayClient client) : base(client) { }
       
       /// <inheritdoc />
       public abstract ValueTask HandleAsync(GuildThreadListSyncEventArgs eventArgs);
       
       /// <inheritdoc />
       public override void Subscribe()
           => Client.GuildThreadListSync += HandleAsync;
       
       /// <inheritdoc />
       public override void UnSubscribe()
           => Client.GuildThreadListSync -= HandleAsync;
   }
}