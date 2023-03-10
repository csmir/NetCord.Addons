using Microsoft.Extensions.Logging;
using NetCord.Gateway;
using NetCord.Services.ApplicationCommands;

namespace NetCord.Addons.Hosting
{
    public class ApplicationCommandServiceHandler<T> : ServiceHandler
        where T : ApplicationCommandContext
    {
        public ApplicationCommandServiceOptions<T> Options { get; }

        public ApplicationCommandService<T> Service { get; }

        public ApplicationCommandServiceHandler(ILogger<ApplicationCommandServiceHandler<T>> logger, ApplicationCommandService<T> service, ApplicationCommandServiceOptions<T> options, IServiceProvider services, GatewayClient client)
            : base(logger, services, client)
        {
            Options = options;
            Service = service;
        }

        public override void Register()
        {
            foreach (var asm in Options.RegistrationAssemblies)
                Service.AddModules(asm);
        }

        public virtual async ValueTask ExecuteAsync(Interaction arg)
        {
            var context = await Options.ContextFactory(this, arg);

            try
            {
                await Service.ExecuteAsync(context);
            }
            catch (Exception ex)
            {
                await ErrorAsync(ex, arg);
            }
        }

        private async ValueTask HandleAsync(Interaction arg)
        {
            switch (Options.Bindings)
            {
                case ServiceBinding.SlashCommand:
                case ServiceBinding.UserCommand:
                case ServiceBinding.MessageCommand:
                    await ExecuteAsync(arg);
                    return;
            }
        }

        public virtual async ValueTask ErrorAsync(Exception exception, Interaction arg)
        {
            if (Options.ErrorAction != null)
                await Options.ErrorAction(this, arg, exception);
        }

        public override void Subscribe()
        {
            Client.InteractionCreate += HandleAsync;
        }

        public override void UnSubscribe()
        {
            Client.InteractionCreate -= HandleAsync;
        }
    }
}
