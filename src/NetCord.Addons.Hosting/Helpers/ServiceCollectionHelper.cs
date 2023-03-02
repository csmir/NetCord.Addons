using Microsoft.Extensions.DependencyInjection;
using NetCord.Gateway;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCord.Addons.Hosting
{
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
