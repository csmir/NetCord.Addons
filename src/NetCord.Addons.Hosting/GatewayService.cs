using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
        public virtual IOptions<GatewayConfigurationOptions> Options { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="options"></param>
        public GatewayService(GatewayClient client, ILoggerFactory loggerFactory, IOptions<GatewayConfigurationOptions> options)
        {
            Logger = loggerFactory.CreateLogger(GetType().Name);
            Client = client;
            Options = options;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Client.StartAsync();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Client.CloseAsync();
        }
    }
}
