using Microsoft.Extensions.Logging;
using NetCord.Addons.Hosting;
using NetCord.Gateway;

namespace NetCord.Addons.Tests.Console
{
    public class Bot : GatewayService
    {
        public Bot(GatewayClient client, ILoggerFactory loggerFactory)
            : base(client, loggerFactory)
        {
            Client.Ready += ReadyAsync;
        }

        private async ValueTask ReadyAsync(ReadyEventArgs arg)
        {
            Logger.LogInformation("Succesfully started your bot!");

            await Task.CompletedTask;
        }
    }
}