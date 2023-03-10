using System.Reflection;

namespace NetCord.Addons.Hosting
{
    public class ServiceOptions
    {
        public ServiceBinding Bindings { get; set; }

        public Assembly[] RegistrationAssemblies { get; set; } = null!;
    }
}
