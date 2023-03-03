using NetCord.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCord.Addons.Rest.Helpers.Properties
{
    public static class EmbedFooterPropertiesHelper
    {
        public static EmbedFooterProperties WithText(this EmbedFooterProperties properties, string text)
        {
            properties.Text = text;
            return properties;
        }

        public static EmbedFooterProperties WithIconUrl(this EmbedFooterProperties properties, string imageUrl)
        {
            properties.IconUrl = imageUrl;
            return properties;
        }
    }
}
