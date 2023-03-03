using NetCord.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents a handler that is responsible for resolving inbound events.
    /// </summary>
    public abstract class GatewayEventHandler : IGatewayEventHandler
    {
        /// <inheritdoc />
        public GatewayClient Client { get; }

        public GatewayEventHandler(GatewayClient client) 
            => Client = client;

        public abstract void Subscribe();

        public abstract void UnSubscribe();
    }
}
