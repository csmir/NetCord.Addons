using Microsoft.Extensions.Hosting;
using NetCord.Addons.Hosting;

var host = Host.CreateDefaultBuilder(args);

host.AddGatewayClient((hostContext, gatewayContext) =>
{

});

var app = host.Build();

await app.RunAsync();