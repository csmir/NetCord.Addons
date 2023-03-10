using Microsoft.Extensions.Logging;
using NetCord.Gateway;
using NetCord.Services.Commands;

namespace NetCord.Addons.Hosting
{
    public class CommandServiceHandler<T> : ServiceHandler
        where T : CommandContext
    {
        public CommandServiceOptions<T> Options { get; }

        public CommandService<T> Service { get; }

        public CommandServiceHandler(ILogger<CommandServiceHandler<T>> logger, CommandService<T> service, CommandServiceOptions<T> options, IServiceProvider services, GatewayClient client)
            : base(logger, services, client)
        {
            Service = service;
            Options = options;
        }

        public override void Register()
        {
            foreach (var asm in Options.RegistrationAssemblies)
                Service.AddModules(asm);
        }

        public virtual async ValueTask ExecuteAsync(Message arg)
        {
            var context = await Options.ContextFactory(this, arg);

            try
            {
                await Service.ExecuteAsync(Options.Prefix?.Length ?? 0, context);
            }
            catch (Exception ex)
            {
                await ErrorAsync(ex, arg);
            }
        }

        private async ValueTask HandleAsync(Message arg)
        {
            if (!arg.Content.StartsWith(Options.Prefix ?? ""))
                return;

            switch (Options.Bindings)
            {
                case ServiceBinding.TextCommand:
                    await ExecuteAsync(arg);
                    return;
            }
        }

        public virtual async ValueTask ErrorAsync(Exception exception, Message arg)
        {
            if (Options.ErrorAction != null)
                await Options.ErrorAction(this, arg, exception);
        }

        public override void Subscribe()
        {
            Client.MessageCreate += HandleAsync;
        }

        public override void UnSubscribe()
        {
            Client.MessageCreate -= HandleAsync;
        }
    }
}
