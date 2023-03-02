using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetCord.Addons.Hosting;
using NetCord.Gateway;

var host = Host.CreateDefaultBuilder(args);

host.ConfigureHostConfiguration(options =>
{
    options.AddEnvironmentVariables("DISCORD_");
});

host.AddGatewayClient<Bot>((hostContext, gatewayContext) =>
{
    gatewayContext.Token = hostContext.Configuration["TOKEN"];
    gatewayContext.Intents = GatewayIntents.All;
});

var app = host.Build();

await app.RunAsync();

public class Bot : GatewayService
{
    public Bot(GatewayClient client, ILoggerFactory loggerFactory, IOptions<GatewayConfigurationOptions> options) 
        : base(client, loggerFactory, options)
    {
    }
}