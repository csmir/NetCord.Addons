using NetCord;
using NetCord.Rest;

namespace NetCord.Addons.Rest.Helpers.Properties
{
    public static class EmbedPropertiesHelper
    {
        public static EmbedProperties WithAuthor(this EmbedProperties properties, EmbedAuthorProperties author)
        {
            properties.Author = author;
            return properties;
        }

        public static EmbedProperties WithFooter(this EmbedProperties properties, EmbedFooterProperties footer)
        {
            properties.Footer = footer;
            return properties;
        }

        public static EmbedProperties WithFields(this EmbedProperties properties, params EmbedFieldProperties[] fields)
        {
            properties.Fields = fields;
            return properties;
        }

        public static EmbedProperties WithDescription(this EmbedProperties properties, string description)
        {
            properties.Description = description;
            return properties;
        }

        public static EmbedProperties WithTitle(this EmbedProperties properties, string title)
        {
            properties.Title = title;
            return properties;
        }
    }
}
