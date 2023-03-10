using NetCord.Gateway;
using NetCord.Services.Commands;

namespace NetCord.Addons.Hosting
{
    public class CommandServiceOptions<T> : ServiceOptions
        where T : CommandContext
    {
        public Func<IServiceHandler, Message, Task<T>> ContextFactory { get; set; } = default!;

        public Func<IServiceHandler, Message, Exception, Task>? ErrorAction { get; set; } = default!;

        public string? Prefix { get; set; }
    }
}
