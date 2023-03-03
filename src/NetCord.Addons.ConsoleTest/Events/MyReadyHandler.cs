using Microsoft.Extensions.Logging;
using NetCord.Addons.Hosting;
using NetCord.Gateway;

namespace NetCord.Addons.Tests.Console.Events
{
    internal class MyReadyHandler : ReadyHandler
    {
        private readonly ILogger<MyReadyHandler> _logger;

        public MyReadyHandler(GatewayClient client, ILogger<MyReadyHandler> logger)
            : base(client)
        {
            _logger = logger;
        }

        public override ValueTask HandleAsync(ReadyEventArgs eventArgs)
        {
            _logger.LogInformation("Bot ready!");

            return ValueTask.CompletedTask;
        }
    }
}
