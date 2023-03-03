using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetCord.Addons.Hosting.Helpers;
using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents a service that automatically starts and stops the <see cref="GatewayClient"/> according to the lifetime of the generic host that configured it.
    /// </summary>
    public abstract class GatewayService : IHostedService
    {
        /// <summary>
        ///     The logger used to log bot events to the log stream of the host.
        /// </summary>
        public virtual ILogger Logger { get; }

        /// <summary>
        ///     The <see cref="GatewayClient"/> this service configures and manages.
        /// </summary>
        public virtual GatewayClient Client { get; }

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

        /// <inheritdoc/>
        public virtual async Task StartAsync(CancellationToken cancellationToken)
        {
            await Client.StartAsync();
        }

        /// <inheritdoc/>
        public virtual async Task StopAsync(CancellationToken cancellationToken)
        {
            await Client.CloseAsync();
        }
    }
}
