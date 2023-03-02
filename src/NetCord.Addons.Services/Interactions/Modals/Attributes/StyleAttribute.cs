using NetCord.Rest;

namespace NetCord.Addons.Services.Interactions
{
    /// <summary>
    ///     Represents an attribute that defines the style (small or big) of a modal input.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class StyleAttribute : Attribute
    {
        /// <summary>
        ///     The style of the modal input.
        /// </summary>
        public TextInputStyle Style { get; }

        /// <summary>
        ///     Creates a new <see cref="StyleAttribute"/> based on the provided <paramref name="style"/>.
        /// </summary>
        /// <param name="style">The style (small or big) of the modal input.</param>
        public StyleAttribute(TextInputStyle style)
        {
            Style = style;
        }
    }
}
