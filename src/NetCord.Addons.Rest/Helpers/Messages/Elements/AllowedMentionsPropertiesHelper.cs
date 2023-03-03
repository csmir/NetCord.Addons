using NetCord.Rest;

namespace NetCord.Addons.Rest.Helpers.Messages
{
    public static class AllowedMentionsPropertiesHelper
    {
        public static AllowedMentionsProperties WithEveryone(this AllowedMentionsProperties properties, bool mentionEveryone)
        {
            properties.Everyone = mentionEveryone;
            return properties;
        }

        public static AllowedMentionsProperties WithRepliedUser(this AllowedMentionsProperties properties, bool mentionRepliedUser)
        {
            properties.ReplyMention = mentionRepliedUser;
            return properties;
        }

        public static AllowedMentionsProperties WithAllowedRoles(this AllowedMentionsProperties properties, params ulong[] roleIds)
        {
            properties.AllowedRoles = roleIds;
            return properties;
        }

        public static AllowedMentionsProperties WithAllowedUsers(this AllowedMentionsProperties properties, params ulong[] userIds)
        {
            properties.AllowedUsers = userIds;
            return properties;
        }
    }
}
