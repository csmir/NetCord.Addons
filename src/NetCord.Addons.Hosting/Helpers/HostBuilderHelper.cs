using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using NetCord.Gateway;

#pragma warning disable CA2208 // Instantiate argument exceptions correctly

namespace NetCord.Addons.Hosting
{
    public static class HostBuilderHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hostBuilder"></param>
        /// <param name="configure"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
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

                services.TryAddEnumerable(ServiceDescriptor.Singleton<GatewayClient>(x =>
                {
                    var token = x.GetRequiredService<TokenFactory>()
                        .GetToken();
                    var config = x.GetRequiredService<GatewayClientConfiguration>();

                    return new(token, config);
                }));

                services.AddHostedService<T>();
            });
            return hostBuilder;
        }
    }
}
