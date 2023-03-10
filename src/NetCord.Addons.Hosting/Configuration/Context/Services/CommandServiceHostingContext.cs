using NetCord.Gateway;
using NetCord.Services.Commands;

namespace NetCord.Addons.Hosting
{
    public class CommandServiceHostingContext<T> : ServiceHostingContext
        where T : CommandContext
    {
        public Func<IServiceHandler, Message, Task<T>> ContextFactory { get; set; } = default!;

        public Func<IServiceHandler, Message, Exception, Task> ErrorAction { get; set; } = default!;

        public CommandServiceConfiguration<T> Configuration { get; set; } = default!;

        public string? Prefix { get; set; }
    }
}
