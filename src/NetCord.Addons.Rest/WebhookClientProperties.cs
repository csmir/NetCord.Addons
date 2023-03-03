using NetCord.Rest;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NetCord.Addons.Rest
{
    /// <summary>
    ///     Represents properties used to create a webhook.
    /// </summary>
    public class WebhookClientProperties
    {
        private readonly static Regex _webhookRegex = new(@"^.*(discord|discordapp)\.com\/api\/webhooks\/([\d]+)\/([a-z0-9_-]+)$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

        /// <summary>
        ///     The ID of the webhook.
        /// </summary>
        public ulong WebhookId { get; set; }

        /// <summary>
        ///     The token of the webhook.
        /// </summary>
        public string WebhookToken { get; set; }

        /// <summary>
        ///     Creates new <see cref="WebhookClientProperties"/> to use when creating a new webhook client.
        /// </summary>
        /// <param name="webhookId"></param>
        /// <param name="webhookToken"></param>
        public WebhookClientProperties(ulong webhookId, string webhookToken)
        {
            WebhookId = webhookId;
            WebhookToken = webhookToken;
        }

        /// <summary>
        ///     Tries to parse a webhook url into a new <see cref="WebhookClientProperties"/>
        /// </summary>
        /// <param name="url">The url to parse.</param>
        /// <param name="properties">A new <see cref="WebhookClientProperties"/>.</param>
        /// <returns>True if successful. False if not.</returns>
        public static bool TryParse(string url, [NotNullWhen(true)] out WebhookClientProperties properties)
        {
            properties = default!;

            if (string.IsNullOrWhiteSpace(url))
                return false;

            var match = _webhookRegex.Match(url);

            if (match is null)
                return false;

            if (!(match.Groups[2].Success && ulong.TryParse(match.Groups[2].Value, out var id)))
                return false;

            if (!match.Groups[3].Success)
                return false;

            var token = match.Groups[3].Value;

            properties = new(id, token);

            return true;
        }

        /// <summary>
        ///     Parses a webhook url into a new <see cref="WebhookClientProperties"/>.
        /// </summary>
        /// <param name="url">The url to parse.</param>
        /// <returns>A new <see cref="WebhookClientProperties"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when the URL is not a valid webhook url.</exception>
        public static WebhookClientProperties Parse(string url)
        {
            if (!TryParse(url, out var properties))
                throw new ArgumentException("Url is not a valid webhook url.", nameof(url));

            return properties;
        }

        /// <summary>
        ///     Creates a new <see cref="WebhookClient"/> from the available values.
        /// </summary>
        /// <param name="configuration">The configuration to be used when creating the client.</param>
        /// <returns>A new <see cref="WebhookClient"/>.</returns>
        public WebhookClient ToClient(WebhookClientConfiguration? configuration = null)
            => new(WebhookId, WebhookToken, configuration);
    }
}
