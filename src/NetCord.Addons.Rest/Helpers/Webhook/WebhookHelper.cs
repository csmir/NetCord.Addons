using NetCord.Rest;

namespace NetCord.Addons.Rest.Helpers.Webhook
{
    /// <summary>
    ///     Represents extension methods that help with creating webhooks. 
    /// </summary>
    public static class WebhookHelper
    {
        /// <summary>
        ///     Gets a webhook from an existing URL and reuses the provided <see cref="RestClient"/> in creating the new <see cref="WebhookClient"/>.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="webhookUrl">The url of the webhook to attach to.</param>
        /// <returns>The <see cref="WebhookClient"/> created with provided url.</returns>
        public static WebhookClient GetWebhook(this RestClient client, string webhookUrl)
            => WebhookClientProperties.Parse(webhookUrl).ToClient(new() { Client = client });

        /// <summary>
        ///     Tries to get a webhook from an existing URL and reuses the provided <see cref="RestClient"/> in creating the new <see cref="WebhookClient"/>.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="webhookUrl">The URL of the webhook to attach to.</param>
        /// <param name="webhook">The <see cref="WebhookClient"/> created with provided url.</param>
        /// <returns>True if successful. False if not.</returns>
        public static bool TryGetWebhook(this RestClient client, string webhookUrl, out WebhookClient webhook)
        {
            webhook = default!;
            if (WebhookClientProperties.TryParse(webhookUrl, out var properties))
            {
                webhook = properties.ToClient(new() { Client = client });
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Gets a webhook from an existing ID and token and reuses the provided <see cref="RestClient"/> in creating the new <see cref="WebhookClient"/>.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="webhookId">The ID of the webhook to attach to.</param>
        /// <param name="webhookToken">The token of the webhook to attach to.</param>
        /// <returns>The <see cref="WebhookClient"/> created with provided url.</returns>
        public static WebhookClient GetWebhook(this RestClient client, ulong webhookId, string webhookToken)
            => new(webhookId, webhookToken, new() { Client = client });
    }
}
