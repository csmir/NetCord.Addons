using Microsoft.Extensions.Logging;
using NetCord.Addons.Hosting;
using NetCord.Addons.Rest;
using NetCord.Gateway;
using NetCord.Rest;

namespace NetCord.Addons.Tests.Console
{
    public class Bot : GatewayService
    {
        public Bot(GatewayClient client, ILoggerFactory loggerFactory)
            : base(client, loggerFactory)
        {

        }
    }
}