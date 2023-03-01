using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using NetCord.Gateway;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
        public static IHostBuilder AddGatewayClient(this IHostBuilder hostBuilder, Action<HostBuilderContext, GatewayHostingContext> configure)
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                var gatewayContext = new GatewayHostingContext();
                configure(context, gatewayContext);

                services.Configure<GatewayConfigurationOptions>(context.Configuration.GetSection(gatewayContext.OptionsRoot));

                if (gatewayContext.Configuration is null)
                    throw new ArgumentNullException(nameof(gatewayContext.Configuration));

                services.AddSingleton(gatewayContext.Configuration);
                services.AddSingleton<TokenFactory>();

                services.TryAddEnumerable(ServiceDescriptor.Singleton<GatewayClient>(x =>
                {
                    var token = x.GetRequiredService<TokenFactory>()
                        .GetToken();
                    var config = x.GetRequiredService<GatewayClientConfiguration>();

                    return new(token, config);
                }));
            });
            return hostBuilder;
        }
    }
}
