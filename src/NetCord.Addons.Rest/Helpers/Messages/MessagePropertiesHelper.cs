using NetCord.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCord.Addons.Rest.Helpers.Messages
{
    public static class MessagePropertiesHelper
    {
        public static MessageProperties WithContent(this MessageProperties properties, string content)
        {
            properties.Content = content;
            return properties;
        }

        public static MessageProperties WithEmbeds(this MessageProperties properties, params EmbedProperties[] embeds)
        {
            properties.Embeds = embeds;
            return properties;
        }

        public static MessageProperties WithAllowedMentions(this MessageProperties properties, AllowedMentionsProperties allowedMentions)
        {
            properties.AllowedMentions = allowedMentions;
            return properties;
        }

        public static MessageProperties WithComponents(this MessageProperties properties, params ComponentProperties[] components)
        {
            properties.Components = components;
            return properties;
        }

        public static MessageProperties WithTextToSpeech(this MessageProperties properties, bool isTts)
        {
            properties.Tts = isTts;
            return properties;
        }

        public static MessageProperties WithAttachments(this MessageProperties properties, params AttachmentProperties[] attachments)
        {
            properties.Attachments = attachments;
            return properties;
        }

        public static MessageProperties WithMessageReference(this MessageProperties properties, MessageReferenceProperties messageReference)
        {
            properties.MessageReference = messageReference;
            return properties;
        }
    }
}
