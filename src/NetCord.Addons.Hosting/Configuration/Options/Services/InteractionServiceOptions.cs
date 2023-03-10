using NetCord.Gateway;
using NetCord.Services.Interactions;

namespace NetCord.Addons.Hosting
{
    public class InteractionServiceOptions<T> : ServiceOptions
        where T : InteractionContext
    {
        public Func<IServiceHandler, Interaction, Task<T>> ContextFactory { get; set; } = default!;

        public Func<IServiceHandler, Interaction, Exception, Task>? ErrorAction { get; set; } = default!;
    }
}
