using Microsoft.Extensions.Hosting;
using NetCord.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCord.Addons.Hosting
{
    /// <summary>
    ///     Represents the context used to start a new <see cref="GatewayClient"/> with a hosted implementor.
    /// </summary>
    public class GatewayHostingContext
    {
        /// <summary>
        ///     The options root for client setup.
        /// </summary>
        public string OptionsRoot { get; set; } = string.Empty;

        /// <summary>
        ///     The configuration used to configure the <see cref="GatewayClient"/>.
        /// </summary>
        public GatewayClientConfiguration Configuration { get; set; } = new();
    }
}
