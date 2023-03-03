using NetCord.Rest;

namespace NetCord.Addons.Rest
{
    public static class InteractionMessagePropertiesHelper
    {
        public static InteractionMessageProperties WithEphemeral(this InteractionMessageProperties properties, bool isEphemeral)
        {
            if (isEphemeral)
                properties.Flags |= MessageFlags.Ephemeral;
            else
                properties.Flags &= ~MessageFlags.Ephemeral;
            return properties;
        }

        public static InteractionMessageProperties WithContent(this InteractionMessageProperties properties, string content)
        {
            properties.Content = content;
            return properties;
        }

        public static InteractionMessageProperties WithEmbeds(this InteractionMessageProperties properties, params EmbedProperties[] embeds)
        {
            properties.Embeds = embeds;
            return properties;
        }

        public static InteractionMessageProperties WithAllowedMentions(this InteractionMessageProperties properties, AllowedMentionsProperties allowedMentions)
        {
            properties.AllowedMentions = allowedMentions;
            return properties;
        }

        public static InteractionMessageProperties WithComponents(this InteractionMessageProperties properties, params ComponentProperties[] components)
        {
            properties.Components = components;
            return properties;
        }

        public static InteractionMessageProperties WithTextToSpeech(this InteractionMessageProperties properties, bool isTts)
        {
            properties.Tts = isTts;
            return properties;
        }

        public static InteractionMessageProperties WithAttachments(this InteractionMessageProperties properties, params AttachmentProperties[] attachments)
        {
            properties.Attachments = attachments;
            return properties;
        }
    }
}
