using Microsoft.Extensions.Logging;
using NetCord.Gateway;

namespace NetCord.Addons.Hosting
{
    public abstract class ServiceHandler : IServiceHandler
    {
        public GatewayClient Client { get; }

        public IServiceProvider Services { get; }

        public ILogger Logger { get; }

        public ServiceHandler(ILogger logger, IServiceProvider services, GatewayClient client)
        {
            Logger = logger;
            Services = services;
            Client = client;
        }

        public abstract void Register();

        public abstract void Subscribe();

        public abstract void UnSubscribe();
    }
}
