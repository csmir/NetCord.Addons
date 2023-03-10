using NetCord.Gateway;
using NetCord.Services.ApplicationCommands;
using NetCord.Services.Interactions;

namespace NetCord.Addons.Hosting
{
    public class ApplicationCommandServiceHostingContext<T> : ServiceHostingContext
        where T : ApplicationCommandContext
    {
        public Func<IServiceHandler, Interaction, Task<T>> ContextFactory { get; set; } = default!;

        public Func<IServiceHandler, Interaction, Exception, Task> ErrorAction { get; set; } = default!;

        public InteractionServiceConfiguration<T> Configuration { get; set; } = default!;
    }
}
