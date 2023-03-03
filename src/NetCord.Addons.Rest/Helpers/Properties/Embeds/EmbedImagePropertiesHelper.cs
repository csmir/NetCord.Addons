using NetCord.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace NetCord.Addons.Rest
{
    public static class EmbedImagePropertiesHelper
    {
        public static EmbedImageProperties WithUrl(this EmbedImageProperties properties, string url)
        {
            properties.Url = url;
            return properties;
        }
    }
}
