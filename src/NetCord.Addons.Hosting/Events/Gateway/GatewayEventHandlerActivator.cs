using Microsoft.Extensions.Hosting;

namespace NetCord.Addons.Hosting.Events
{
    /// <summary>
    ///     Represents an activator for all registered <see cref="IGatewayEventHandler"/>'s. 
    ///     This service provides control over all event handlers and exposes methods to mass subscribe and unsubscribe them. 
    /// </summary>
    public class GatewayEventHandlerActivator : IHostedService
    {
        private readonly IEnumerable<IGatewayEventHandler> _handlers;

        public GatewayEventHandlerActivator(IEnumerable<IGatewayEventHandler> handlers)
        {
            _handlers = handlers;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Subscribe();
            await Task.CompletedTask;
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
