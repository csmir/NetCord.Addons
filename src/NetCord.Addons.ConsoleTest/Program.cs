using Microsoft.Extensions.Hosting;
using NetCord.Addons.Hosting;
using NetCord.Addons.Tests.Console;
using NetCord.Gateway;
using NetCord.Services.ApplicationCommands;
using NetCord.Services.Commands;
using NetCord.Services.Interactions;

var host = Host.CreateDefaultBuilder(args);

host.AddGatewayClient<Bot>((hostContext, gatewayContext) =>
{
    gatewayContext.Token = hostContext.Configuration["token"]!;
    gatewayContext.Intents = GatewayIntents.AllNonPrivileged;
});

host.AddEventHandlers();

host.AddCommandService<CommandContext>((hostContext, serviceContext) =>
{
    serviceContext.Configuration = new()
    {
        IgnoreCase = false,
    };
    serviceContext.Prefix = hostContext.Configuration["prefix"];
    serviceContext.ContextFactory = (handler, msg) =>
    {
        return new(msg, handler.Client);
    };
});

host.AddApplicationCommandService<SlashCommandContext>((hostContext, serviceContext) =>
{
    serviceContext.Bindings = ServiceBinding.SlashCommand;
    serviceContext.ContextFactory = (handler, itr) =>
    {
        return new((SlashCommandInteraction)itr, handler.Client);
    };
});

host.AddApplicationCommandService<ApplicationCommandContext>((hostContext, serviceContext) =>
{
    serviceContext.Bindings = ServiceBinding.SlashCommand | ServiceBinding.UserCommand | ServiceBinding.MessageCommand;
    serviceContext.ContextFactory = (handler, itr) =>
    {
        return itr switch
        {
            _ => throw new NotImplementedException()
        };
    };
});

var app = host.Build();

await app.RunAsync();