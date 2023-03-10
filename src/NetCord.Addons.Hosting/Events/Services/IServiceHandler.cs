using Microsoft.Extensions.Logging;
using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    public interface IServiceHandler
    {
        /// <summary>
        ///     The gateway client that should be used to subscribe and unsubscribe from events.
        /// </summary>
        public GatewayClient Client { get; }

        public IServiceProvider Services { get; }

        public ILogger Logger { get; }

        public void Register();

        /// <summary>
        ///     Subscribes the event to the implemented handling method.
        /// </summary>
        public void Subscribe();

        /// <summary>
        ///     Unsubscribes the event from the implemented handling method.
        /// </summary>
        public void UnSubscribe();
    }
}
