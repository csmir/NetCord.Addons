using Microsoft.Extensions.DependencyInjection;
using NetCord.Gateway;
using System.ComponentModel;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents extension methods that help configure the service collection.
    /// </summary>
    public static class ServiceCollectionHelper
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IServiceCollection AddClientConfiguration(this IServiceCollection services, GatewayHostingContext context)
        {
            var config = new GatewayClientConfiguration()
            {
                ConnectionProperties = context.ConnectionProperties,
                RestClientConfiguration = context.RestClientConfiguration,
                Hostname = context.HostName,
                Intents = context.Intents,
                Presence = context.Presence,
                Shard = context.Shard,
                Version = context.Version,
                LargeThreshold = context.LargeThreshold,
                WebSocket = context.WebSocket,
            };

            services.AddSingleton(config);

            return services;
        }
    }
}
