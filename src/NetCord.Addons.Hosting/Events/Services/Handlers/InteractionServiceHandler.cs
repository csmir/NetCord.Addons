using Microsoft.Extensions.Logging;
using NetCord.Gateway;
using NetCord.Services.Interactions;

namespace NetCord.Addons.Hosting
{
    public class InteractionServiceHandler<T> : ServiceHandler
        where T : InteractionContext
    {
        public InteractionServiceOptions<T> Options { get; }

        public InteractionService<T> Service { get; }

        public InteractionServiceHandler(ILogger<InteractionServiceHandler<T>> logger, InteractionService<T> service, InteractionServiceOptions<T> options, IServiceProvider services, GatewayClient client)
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
                case ServiceBinding.ButtonInteraction:
                case ServiceBinding.ModalInteraction:
                case ServiceBinding.SelectMenuInteraction:
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
