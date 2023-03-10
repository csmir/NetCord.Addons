using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using NetCord.Addons.Hosting.Events;
using NetCord.Gateway;
using NetCord.Services.ApplicationCommands;
using NetCord.Services.Commands;
using NetCord.Services.Interactions;
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
                services.TryAddSingleton<TokenFactory>();

                services.TryAddSingleton<GatewayClient>(x =>
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
                        services.TryAddSingleton(targetType, discoveredType);
                }

                services.AddHostedService<GatewayEventHandlerActivator>();
            });

            return hostBuilder;
        }

        public static IHostBuilder AddCommandService<T, THandler>(this IHostBuilder hostBuilder, Action<HostBuilderContext, CommandServiceHostingContext<T>> configure)
            where T : CommandContext where THandler : CommandServiceHandler<T>
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                var serviceContext = new CommandServiceHostingContext<T>();
                configure(context, serviceContext);

                services.Configure<CommandServiceOptions<T>>(options =>
                {
                    options.ContextFactory = serviceContext.ContextFactory;
                    options.ErrorAction = serviceContext.ErrorAction;
                    options.Bindings = serviceContext.Bindings;
                    options.RegistrationAssemblies = serviceContext.RegistrationAssemblies;
                    options.Prefix = serviceContext.Prefix;
                });

                services.TryAddSingleton(serviceContext.Configuration);
                services.TryAddSingleton<CommandService<T>>();

                services.TryAddSingleton<IServiceHandler, THandler>();

                services.AddHostedService<ServiceHandlerActivator>();
            });

            return hostBuilder;
        }

        public static IHostBuilder AddCommandService<T>(this IHostBuilder hostBuilder, Action<HostBuilderContext, CommandServiceHostingContext<T>> configure)
            where T : CommandContext
        {
            return hostBuilder.AddCommandService<T, CommandServiceHandler<T>>(configure);
        }

        public static IHostBuilder AddApplicationCommandService<T, THandler>(this IHostBuilder hostBuilder, Action<HostBuilderContext, ApplicationCommandServiceHostingContext<T>> configure)
            where T : ApplicationCommandContext where THandler : ApplicationCommandServiceHandler<T>
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                var serviceContext = new ApplicationCommandServiceHostingContext<T>();
                configure(context, serviceContext);

                services.Configure<ApplicationCommandServiceOptions<T>>(options =>
                {
                    options.ContextFactory = serviceContext.ContextFactory;
                    options.ErrorAction = serviceContext.ErrorAction;
                    options.Bindings = serviceContext.Bindings;
                    options.RegistrationAssemblies = serviceContext.RegistrationAssemblies;
                });

                services.TryAddSingleton(serviceContext.Configuration);
                services.TryAddSingleton<ApplicationCommandService<T>>();

                services.TryAddSingleton<IServiceHandler, THandler>();

                services.AddHostedService<ServiceHandlerActivator>();
            });

            return hostBuilder;
        }

        public static IHostBuilder AddApplicationCommandService<T>(this IHostBuilder hostBuilder, Action<HostBuilderContext, ApplicationCommandServiceHostingContext<T>> configure)
            where T : ApplicationCommandContext
        {
            return hostBuilder.AddApplicationCommandService<T, ApplicationCommandServiceHandler<T>>(configure);
        }

        public static IHostBuilder AddInteractionService<T, THandler>(this IHostBuilder hostBuilder, Action<HostBuilderContext, InteractionServiceHostingContext<T>> configure)
            where T : InteractionContext where THandler : InteractionServiceHandler<T>
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                var serviceContext = new InteractionServiceHostingContext<T>();
                configure(context, serviceContext);

                services.Configure<InteractionServiceOptions<T>>(options =>
                {
                    options.ContextFactory = serviceContext.ContextFactory;
                    options.ErrorAction = serviceContext.ErrorAction;
                    options.Bindings = serviceContext.Bindings;
                    options.RegistrationAssemblies = serviceContext.RegistrationAssemblies;
                });

                services.TryAddSingleton(serviceContext.Configuration);
                services.TryAddSingleton<InteractionService<T>>();

                services.TryAddSingleton<IServiceHandler, THandler>();

                services.AddHostedService<ServiceHandlerActivator>();
            });

            return hostBuilder;
        }

        public static IHostBuilder AddInteractionService<T>(this IHostBuilder hostBuilder, Action<HostBuilderContext, InteractionServiceHostingContext<T>> configure)
            where T : InteractionContext
        {
            return hostBuilder.AddInteractionService<T, InteractionServiceHandler<T>>(configure);
        }
    }
}
