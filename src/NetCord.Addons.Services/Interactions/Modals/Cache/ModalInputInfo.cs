using NetCord.Rest;
using System.Reflection;
using System.Runtime.InteropServices;

namespace NetCord.Addons.Services.Interactions
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ModalInputInfo
    {
        public string CustomId { get; } = string.Empty;

        public TextInputStyle Style { get; } = TextInputStyle.Short;

        public string Label { get; } = string.Empty;

        public string? PlaceHolder { get; } = null;

        public int? MaxLength { get; } = null;

        public bool? Required { get; } = null;

        public int? MinLength { get; } = null;

        public PropertyInfo Property { get; }

        public ModalInputInfo(PropertyInfo property, IEnumerable<Attribute> attributes)
        {
            Property = property;

            foreach (var attribute in attributes)
                switch (attribute)
                {
                    case CustomIdAttribute idAttribute:
                        CustomId = idAttribute.CustomId;
                        break;
                    case InputRestrictionAttribute restrictionAttribute:
                        MinLength = restrictionAttribute.MinLength;
                        MaxLength = restrictionAttribute.MaxLength;
                        break;
                    case StyleAttribute styleAttribute:
                        Style = styleAttribute.Style;
                        break;
                    case PlaceHolderAttribute holderAttribute:
                        PlaceHolder = holderAttribute.PlaceHolder;
                        break;
                }
        }
    }
}
