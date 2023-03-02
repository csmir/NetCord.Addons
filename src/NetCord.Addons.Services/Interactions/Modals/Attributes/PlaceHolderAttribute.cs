namespace NetCord.Addons.Services.Interactions
{
    /// <summary>
    ///     Represents an attribute that defines the placeholder value of a modal input.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class PlaceHolderAttribute : Attribute
    {
        /// <summary>
        ///     The placeholder of the modal input.
        /// </summary>
        public string PlaceHolder { get; }

        /// <summary>
        ///     Creates a new <see cref="PlaceHolderAttribute"/> based on the provided <paramref name="placeHolder"/>.
        /// </summary>
        /// <param name="placeHolder">The placeholder that should sit in the value box before user input.</param>
        public PlaceHolderAttribute(string placeHolder)
        {
            PlaceHolder = placeHolder;
        }
    }
}
