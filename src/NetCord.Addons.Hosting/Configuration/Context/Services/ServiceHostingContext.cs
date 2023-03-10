using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace NetCord.Addons.Hosting
{
    public class ServiceHostingContext
    {
        [DisallowNull]
        public ServiceBinding Bindings { get; set; } = ServiceBinding.None;

        public Assembly[] RegistrationAssemblies { get; set; } = new[] { Assembly.GetEntryAssembly()! };
    }
}
