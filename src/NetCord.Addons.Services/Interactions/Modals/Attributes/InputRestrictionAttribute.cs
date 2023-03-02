namespace NetCord.Addons.Services.Interactions
{
    /// <summary>
    ///     Represents an attribute that restricts a modal input by max length, min length or requirement.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class InputRestrictionAttribute : Attribute
    {
        /// <summary>
        ///     Defines if the modal input is required or not.
        /// </summary>
        public bool IsRequired { get; }

        /// <summary>
        ///     Defines the minimum length of the modal input.
        /// </summary>
        public int? MinLength { get; } = null;

        /// <summary>
        ///     Defines the maximum length of the modal input.
        /// </summary>
        public int? MaxLength { get; } = null;

        /// <summary>
        ///     Creates a new <see cref="InputRestrictionAttribute"/> based on if its required or not.
        /// </summary>
        /// <param name="isRequired">If the modal input is required or not.</param>
        public InputRestrictionAttribute(bool isRequired)
        {
            IsRequired = isRequired;
        }

        /// <summary>
        ///     Creates a new <see cref="InputRestrictionAttribute"/> based on a min and max length.
        /// </summary>
        /// <param name="minLength">The minimum length, null if not relevant.</param>
        /// <param name="maxLength">The maximum length, null if not relevant.</param>
        public InputRestrictionAttribute(int? minLength, int? maxLength)
            : this(false)
        {
            MinLength = minLength;
            MaxLength = maxLength;
        }

        /// <summary>
        ///     Creates a new <see cref="InputRestrictionAttribute"/> based on a min length, max length and if its required or not.
        /// </summary>
        /// <param name="isRequired">If the modal input is required or not.</param>
        /// <param name="minLength">The minimum length, null if not relevant.</param>
        /// <param name="maxLength">The maximum length, null if not relevant.</param>
        public InputRestrictionAttribute(bool isRequired, int? minLength, int? maxLength)
            : this(isRequired)
        {
            MinLength = minLength;
            MaxLength = maxLength;
        }
    }
}
