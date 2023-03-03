using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetCord.Addons.Hosting;
using NetCord.Addons.Tests;
using NetCord.Addons.Tests.Console;
using NetCord.Gateway;

var host = Host.CreateDefaultBuilder(args);

host.AddGatewayClient<Bot>((hostContext, gatewayContext) =>
{
    gatewayContext.Token = hostContext.Configuration["token"]!;
    gatewayContext.Intents = GatewayIntents.AllNonPrivileged;
});

var app = host.Build();

await app.RunAsync();