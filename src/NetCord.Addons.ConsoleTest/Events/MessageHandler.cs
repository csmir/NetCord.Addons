using NetCord.Addons.Hosting.Events.Handlers;
using NetCord.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCord.Addons.Tests.Console.Events
{
    internal class MessageHandler : MessageCreateHandler
    {
        public MessageHandler(GatewayClient client) 
            : base(client)
        {

        }

        protected override ValueTask HandleAsync(Message arg)
        {
            throw new NotImplementedException();
        }
    }
}
