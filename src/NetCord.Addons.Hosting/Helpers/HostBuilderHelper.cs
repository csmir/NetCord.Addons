using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCord.Addons.Hosting.Events;
using NetCord.Gateway;
using System.Reflection;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents extension methods that support integrating NetCord into .NET's generic <see cref="IHost"/>.
    /// </summary>
    public static class HostBuilderHelper
    {
        /// <summary>
        ///     Configures and adds a <see cref="GatewayClient"/> to the generic host. This client is available through dependency injection and will be automatically started.
        /// </summary>
        /// <typeparam name="T">The implementor responsible for starting and stopping the gateway connection.</typeparam>
        /// <param name="hostBuilder"></param>
        /// <param name="configure">Configure the <see cref="GatewayHostingContext"/> based on the <see cref="HostBuilderContext"/>.</param>
        /// <returns>The same <see cref="IHostBuilder"/> for chained calls.</returns>
        public static IHostBuilder AddGatewayClient<T>(this IHostBuilder hostBuilder, Action<HostBuilderContext, GatewayHostingContext> configure)
            where T : GatewayService
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                var gatewayContext = new GatewayHostingContext();
                configure(context, gatewayContext);

                services.Configure<TokenConfigurationOptions>(options =>
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

        /// <summary>
        ///     Adds all available <see cref="GatewayEventHandler"/>'s in the provided assembly to the underlying servicecollection and configures the 
        ///     <see cref="GatewayEventHandlerActivator"/> to resolve them automatically on startup.
        /// </summary>
        /// <param name="hostBuilder"></param>
        /// <param name="handlerAssembly">The assembly to use for registering your event handlers. When null, will default to <see cref="Assembly.GetEntryAssembly"/>.</param>
        /// <returns>The same <see cref="IHostBuilder"/> for chained calls.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="handlerAssembly"/> is null and no entry assembly can be resolved.</exception>
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
