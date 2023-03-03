using Microsoft.Extensions.Hosting;

namespace NetCord.Addons.Hosting.Events
{
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

        public void Subscribe()
        {
            foreach (var handler in _handlers)
                handler.Subscribe();
        }

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
