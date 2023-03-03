using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetCord.Addons.Hosting.Helpers;
using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class GatewayService : IHostedService
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual ILogger Logger { get; }

        /// <summary>
        /// 
        /// </summary>
        public virtual GatewayClient Client { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="options"></param>
        public GatewayService(GatewayClient client, ILoggerFactory loggerFactory)
        {
            Logger = loggerFactory.CreateLogger(GetType().Name);
            Client = client;

            Client.Log += LogAsync;
        }

        protected virtual async ValueTask LogAsync(LogMessage arg)
        {
            Logger.Log(arg.Severity.ToLogLevel(), "{}", arg.ToLogString());
            await Task.CompletedTask;
        }

        public virtual async Task StartAsync(CancellationToken cancellationToken)
        {
            await Client.StartAsync();
        }

        public virtual async Task StopAsync(CancellationToken cancellationToken)
        {
            await Client.CloseAsync();
        }
    }
}
