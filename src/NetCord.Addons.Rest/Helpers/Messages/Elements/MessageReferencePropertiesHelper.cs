using NetCord.Rest;

namespace NetCord.Addons.Rest.Helpers.Messages
{
    public static class MessageReferencePropertiesHelper
    {
        public static MessageReferenceProperties WithMessageId(this MessageReferenceProperties properties, ulong messageId)
        {
            properties.Id = messageId;
            return properties;
        }

        public static MessageReferenceProperties WithFailIfNotExists(this MessageReferenceProperties properties, bool failIfNotExists)
        {
            properties.FailIfNotExists = failIfNotExists;
            return properties;
        }
    }
}
