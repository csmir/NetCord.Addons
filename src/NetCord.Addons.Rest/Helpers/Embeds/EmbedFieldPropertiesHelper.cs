using NetCord.Rest;

namespace NetCord.Addons.Rest
{
    public static class EmbedFieldPropertiesHelper
    {
        public static EmbedFieldProperties WithInline(this EmbedFieldProperties properties, bool isInline)
        {
            properties.Inline = isInline;
            return properties;
        }

        public static EmbedFieldProperties WithTitle(this EmbedFieldProperties properties, string title)
        {
            properties.Title = title;
            return properties;
        }

        public static EmbedFieldProperties WithDescription(this EmbedFieldProperties properties, string text)
        {
            properties.Description = text;
            return properties;
        }
    }
}
