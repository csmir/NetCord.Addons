using System.Reflection;
using System.Runtime.InteropServices;

namespace NetCord.Addons.Services.Interactions
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ModalInfo
    {
        public Type Type { get; }

        public string Title { get; }

        public string CustomId { get; }

        public ModalInputInfo[] Inputs { get; }

        public ModalInfo(Modal modal)
        {
            var type = modal.GetType();

            Type = type;
            Inputs = GetInputs(type).ToArray();
            CustomId = modal.CustomId;
            Title = modal.Title;
        }

        private static IEnumerable<ModalInputInfo> GetInputs(Type type)
        {
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty);

            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(string))
                {
                    var attributes = property.GetCustomAttributes();
                    if (attributes.Any(x => x is CustomIdAttribute))
                        yield return new ModalInputInfo(property, attributes);
                }
            }
        }
    }
}
