namespace NetCord.Addons.Services.Interactions
{
    /// <summary>
    ///     Represents an attribute that marks a parameter as modal input, as well as defining its custom ID.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class CustomIdAttribute : Attribute
    {
        /// <summary>
        ///     The custom ID for provided modal input.
        /// </summary>
        public string CustomId { get; }

        /// <summary>
        ///     Creates a new <see cref="CustomIdAttribute"/> from the provided custom ID.
        /// </summary>
        /// <param name="customId">The custom ID, without parameter formatting.</param>
        public CustomIdAttribute(string customId)
        {
            CustomId = customId;
        }
    }
}
