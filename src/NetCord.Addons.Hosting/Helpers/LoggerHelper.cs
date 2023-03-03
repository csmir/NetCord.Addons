using Microsoft.Extensions.Logging;
using NetCord.Gateway;
using System.Text;

namespace NetCord.Addons.Hosting.Helpers
{
    /// <summary>
    ///     Represents extension methods for configuring logs compatible with <see cref="ILogger"/>.
    /// </summary>
    public static class LoggerHelper
    {
        public static LogLevel ToLogLevel(this LogSeverity severity)
            => severity switch
            {
                LogSeverity.Info => LogLevel.Information,
                LogSeverity.Error => LogLevel.Error,
                _ => LogLevel.Debug
            };

        public static string ToLogString(this LogMessage message)
        {
            var sb = new StringBuilder();

            sb.Append(message.Message);
            sb.Append('.');

            if (message.Description is not null)
                sb.Append($" {message.Description}");

            if (message.Exception is not null)
                sb.Append($"\n{message.Exception}");

            return sb.ToString();
        }
    }
}
