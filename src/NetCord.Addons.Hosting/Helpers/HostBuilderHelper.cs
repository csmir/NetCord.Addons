using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCord.Addons.Hosting.Events;
using NetCord.Gateway;
using System.Reflection;

namespace NetCord.Addons.Hosting
{
    public static class HostBuilderHelper
    {
        public static IHostBuilder AddGatewayClient<T>(this IHostBuilder hostBuilder, Action<HostBuilderContext, GatewayHostingContext> configure)
            where T : GatewayService
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                var gatewayContext = new GatewayHostingContext();
                configure(context, gatewayContext);

                services.Configure<GatewayConfigurationOptions>(options =>
                {
                    options.Token = gatewayContext.Token!;
                });

                services.AddClientConfiguration(gatewayContext);
                services.AddSingleton<TokenFactory>();

                services.AddSingleton<GatewayClient>(x =>
                {
                    var token = x.GetRequiredService<TokenFactory>()
                        .GetToken();
                    var config = x.GetRequiredService<GatewayClientConfiguration>();

                    return new(token, config);
                });

                services.AddHostedService<T>();
            });
            return hostBuilder;
        }

        public static IHostBuilder AddEventHandlers(this IHostBuilder hostBuilder, Assembly? handlerAssembly = null)
        {
            handlerAssembly ??= Assembly.GetEntryAssembly();

            if (handlerAssembly is null)
                throw new ArgumentNullException(
                    paramName: nameof(handlerAssembly),
                    message: "Unable to discover entry assembly automatically. handlerAssembly will need to be manually implemented.");

            var discoveredTypes = handlerAssembly.GetTypes();
            var targetType = typeof(IGatewayEventHandler);

            hostBuilder.ConfigureServices((services) =>
            {
                foreach (var discoveredType in discoveredTypes)
                {
                    if (discoveredType.IsAssignableTo(targetType) && !discoveredType.IsAbstract)
                        services.AddSingleton(targetType, discoveredType);
                }

                services.AddHostedService<GatewayEventHandlerActivator>();
            });

            return hostBuilder;
        }
    }
}
