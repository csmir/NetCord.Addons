using NetCord.Gateway;
using NetCord.Services.ApplicationCommands;

namespace NetCord.Addons.Hosting
{
    public class ApplicationCommandServiceOptions<T> : ServiceOptions
        where T : ApplicationCommandContext
    {
        public Func<IServiceHandler, Interaction, Task<T>> ContextFactory { get; set; } = default!;

        public Func<IServiceHandler, Interaction, Exception, Task>? ErrorAction { get; set; } = default!;
    }
}
