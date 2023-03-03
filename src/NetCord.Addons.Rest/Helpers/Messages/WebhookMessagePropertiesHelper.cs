using NetCord.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCord.Addons.Rest.Helpers.Messages
{
    public static class WebhookMessagePropertiesHelper
    {
        public static WebhookMessageProperties WithContent(this WebhookMessageProperties properties, string content)
        {
            properties.Content = content;
            return properties;
        }

        public static WebhookMessageProperties WithEmbeds(this WebhookMessageProperties properties, params EmbedProperties[] embeds)
        {
            properties.Embeds = embeds;
            return properties;
        }

        public static WebhookMessageProperties WithAllowedMentions(this WebhookMessageProperties properties, AllowedMentionsProperties allowedMentions)
        {
            properties.AllowedMentions = allowedMentions;
            return properties;
        }

        public static WebhookMessageProperties WithComponents(this WebhookMessageProperties properties, params ComponentProperties[] components)
        {
            properties.Components = components;
            return properties;
        }

        public static WebhookMessageProperties WithTextToSpeech(this WebhookMessageProperties properties, bool isTts)
        {
            properties.Tts = isTts;
            return properties;
        }

        public static WebhookMessageProperties WithAttachments(this WebhookMessageProperties properties, params AttachmentProperties[] attachments)
        {
            properties.Attachments = attachments;
            return properties;
        }

        public static WebhookMessageProperties WithUsername(this WebhookMessageProperties properties, string username)
        {
            properties.Username = username;
            return properties;
        }

        public static WebhookMessageProperties WithAvatarUrl(this WebhookMessageProperties properties, string avatarUrl)
        {
            properties.AvatarUrl = avatarUrl;
            return properties;
        }

        public static WebhookMessageProperties WithThreadName(this WebhookMessageProperties properties, string threadName)
        {
            properties.ThreadName = threadName;
            return properties;
        }
    }
}
