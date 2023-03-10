using Microsoft.Extensions.Logging;
using NetCord.Addons.Hosting;
using NetCord.Gateway;
using NetCord.Services.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCord.Addons.Tests.Console
{
    internal class MyInteractionHandler : InteractionServiceHandler<ButtonInteractionContext>
    {
        public MyInteractionHandler(ILogger<InteractionServiceHandler<ButtonInteractionContext>> logger, InteractionService<ButtonInteractionContext> service, InteractionServiceOptions<ButtonInteractionContext> options, IServiceProvider services, GatewayClient client) 
            : base(logger, service, options, services, client)
        {
        }

        public override ValueTask ExecuteAsync(Interaction arg)
        {
            return base.ExecuteAsync(arg);
        }
    }
}
