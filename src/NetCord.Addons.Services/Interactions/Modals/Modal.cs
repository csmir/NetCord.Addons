using NetCord.Rest;
using NetCord.Services.Interactions;
using System.Diagnostics.CodeAnalysis;

namespace NetCord.Addons.Services.Interactions
{
    /// <summary>
    ///     Represents an modal instance which can be used to build new <see cref="ModalProperties"/>.
    /// </summary>
    /// <remarks>
    ///     Inherit this type and implement your own parameters to define modal inputs. 
    ///     Newly implemented parameters need to have a getter, a setter, and need to be marked with <see cref="CustomIdAttribute"/>.
    ///     <list type="bullet">
    ///         <item><description><see cref="InputRestrictionAttribute"/> can be used to set if an input is required or not, its minimum length and its maximum length.</description></item>
    ///         <item><description><see cref="PlaceHolderAttribute"/> can be used to set a placeholder before the user enters anything in the value box.</description></item>
    ///         <item><description><see cref="StyleAttribute"/> can be used to set a style (small or big) for the value box.</description></item>
    ///         <item><description><see cref="LabelAttribute"/> can be used to define a label for the input.</description></item>
    ///     </list>
    /// </remarks>
    public abstract class Modal
    {
        /// <summary>
        ///     The custom ID of the modal. This ID should be the same as the <see cref="InteractionAttribute"/> marked method that will handle it.
        /// </summary>
        /// <remarks>
        ///     The custom ID should *not* contain any parameter formatting, as this will be handled by <see cref="ModalHelper.ToModalProperties(Modal, string[])"/>.
        /// </remarks>
        [DisallowNull]
        public abstract string CustomId { get; }

        /// <summary>
        ///     The title of the modal that displays at the top of the input box.
        /// </summary>
        [DisallowNull]
        public abstract string Title { get; }

        public static implicit operator ModalProperties(Modal modal)
        {
            return modal.ToModalProperties();
        }
    }
}
