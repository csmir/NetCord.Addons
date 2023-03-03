using NetCord;
using NetCord.Rest;
using System.Data;
using System.Runtime.CompilerServices;

namespace NetCord.Addons.Rest
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

        public static EmbedProperties WithImage(this EmbedProperties properties, EmbedImageProperties image)
        {
            properties.Image = image;
            return properties;
        }

        public static EmbedProperties WithTitleUrl(this EmbedProperties properties, string titleUrl)
        {
            properties.Url = titleUrl;
            return properties;
        }

        public static EmbedProperties WithThumbnail(this EmbedProperties properties, EmbedThumbnailProperties thumbnail)
        {
            properties.Thumbnail = thumbnail;
            return properties;
        }

        public static EmbedProperties WithTimestamp(this EmbedProperties properties, DateTimeOffset timestamp)
        {
            properties.Timestamp = timestamp;
            return properties;
        }
        
        public static EmbedProperties WithColor(this EmbedProperties properties, Color color)
        {
            properties.Color = color;
            return properties;
        }
    }
}
