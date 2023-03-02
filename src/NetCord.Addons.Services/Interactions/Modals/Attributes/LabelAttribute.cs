namespace NetCord.Addons.Services.Interactions
{
    /// <summary>
    ///     Represents an attribute that defines the label of a modal input.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class LabelAttribute : Attribute
    {
        /// <summary>
        ///     The label of the modal input.
        /// </summary>
        public string Label { get; }

        /// <summary>
        ///     Creates a new <see cref="LabelAttribute"/> with provided <paramref name="label"/>.
        /// </summary>
        /// <param name="label">The label for this modal input.</param>
        public LabelAttribute(string label)
        {
            Label = label;
        }
    }
}
