using Microsoft.Extensions.Hosting;

namespace NetCord.Addons.Hosting
{
    public class ServiceHandlerActivator : IHostedService
    {
        private readonly IEnumerable<IServiceHandler> _handlers;

        public ServiceHandlerActivator(IEnumerable<IServiceHandler> handlers)
        {
            _handlers = handlers;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Register();
            Subscribe();
            await Task.CompletedTask;
        }

        public void Register()
        {
            foreach (var handler in _handlers)
                handler.Register();
        }

        /// <summary>
        ///     Subscribes all available event handlers to their respective events.
        /// </summary>
        public void Subscribe()
        {
            foreach (var handler in _handlers)
                handler.Subscribe();
        }

        /// <summary>
        ///     Unsubscribes all available event handlers from their respective events.
        /// </summary>
        public void Unsubscribe()
        {
            foreach (var handler in _handlers)
                handler.UnSubscribe();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Unsubscribe();
            await Task.CompletedTask;
        }
    }
}
