using NetCord.Rest;
using NetCord.Services.Interactions;
using System.ComponentModel;
using System.Text;

namespace NetCord.Addons.Services.Interactions
{
    /// <summary>
    ///     Represents a number of helper methods intended to make working with modals considerably easier.
    /// </summary>
    public static class ModalHelper
    {
        private readonly static Lazy<Dictionary<string, ModalInfo>> _modalCache = new(isThreadSafe: true);
        private readonly static object _lock = new();

        /// <summary>
        ///     Turns an modalInfo into newly created <see cref="ModalProperties"/> based on the attributed values.
        /// </summary>
        /// <remarks>
        ///     The first time this method is called, whether it be implicit or explicit, it will cache the provided <paramref name="modal"/>.
        ///     This cached object will be reused when fetching the modalInfo through <see cref="ModalHelper.Modal{T}(ModalSubmitInteractionContext)"/> or by calling this method again.
        /// </remarks>
        /// <param name="modal"></param>
        /// <param name="parameters">The (optional) parameters you want to provide when submitting this modalInfo to be handled.</param>
        /// <returns>A new <see cref="ModalProperties"/> from the provided <paramref name="modal"/>.</returns>
        public static ModalProperties ToModalProperties(this Modal modal, params string[] parameters)
        {
            return modal.ToModalProperties(':', parameters);
        }

        /// <summary>
        ///     Turns an modalInfo into newly created <see cref="ModalProperties"/> based on the attributed values.
        /// </summary>
        /// <remarks>
        ///     The first time this method is called, whether it be implicit or explicit, it will cache the provided <paramref name="modal"/>.
        ///     This cached object will be reused when fetching the modalInfo through <see cref="ModalHelper.Modal{T}(ModalSubmitInteractionContext)"/> or by calling this method again.
        /// </remarks>
        /// <param name="modal"></param>
        /// <param name="seperator">Can be used to change the default (:) seperator in case it was modified via <see cref="InteractionServiceConfiguration{TContext}.ParameterSeparator"/></param>
        /// <param name="parameters">The (optional) parameters you want to provide when submitting this modalInfo to be handled.</param>
        /// <returns>A new <see cref="ModalProperties"/> from the provided <paramref name="modal"/>.</returns>
        public static ModalProperties ToModalProperties(this Modal modal, char seperator, params string[] parameters)
        {
            lock (_lock)
            {
                if (!_modalCache.Value.TryGetValue(modal.CustomId, out var modalInfo))
                    modalInfo = modal.Cache(true);

                var sb = new StringBuilder();

                sb.Append(modalInfo.CustomId);
                foreach (var parameter in parameters)
                {
                    sb.Append(seperator);
                    sb.Append(parameter);
                }

                var mp = new ModalProperties(sb.ToString(), modalInfo.Title, modalInfo.ToInputProperties());

                return mp;
            }
        }

        /// <summary>
        ///     Generates a range of <see cref="TextInputProperties"/>s from the provided <paramref name="modalInfo"/>.
        /// </summary>
        /// <param name="modalInfo"></param>
        /// <returns>A range of <see cref="TextInputProperties"/> that can be used to construct a new <see cref="ModalProperties"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static IEnumerable<TextInputProperties> ToInputProperties(this ModalInfo modalInfo)
        {
            foreach (var inputInfo in modalInfo.Inputs)
            {
                yield return new TextInputProperties(inputInfo.CustomId, inputInfo.Style, inputInfo.Label)
                {
                    Placeholder = inputInfo.PlaceHolder,
                    MaxLength = inputInfo.MaxLength,
                    MinLength = inputInfo.MinLength,
                    Required = inputInfo.Required,
                };
            }
        }

        /// <summary>
        ///     Allows you to create and cache a <see cref="ModalInfo"/> from the provided <paramref name="modal"/>.
        /// </summary>
        /// <param name="modal"></param>
        /// <returns>A new <see cref="ModalInfo"/> that has been cached for later use.</returns>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static ModalInfo Cache(this Modal modal, bool isLocked = false)
        {
            var info = new ModalInfo(modal);

            if (isLocked)
                lock (_lock)
                    _modalCache.Value.Add(info.CustomId, info);
            else
                _modalCache.Value.Add(info.CustomId, info);

            return info;
        }

        /// <summary>
        ///     Fetches an instance of <typeparamref name="T"/> with populated values based on the <paramref name="context"/>.
        /// </summary>
        /// <typeparam name="T">The type that should be instanced and populated with the values from the <paramref name="context"/>.</typeparam>
        /// <param name="context"></param>
        /// <returns>A new <typeparamref name="T"/> which can be used to handle strongly typed modal behavior.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the length of the modal does not match the receiving end.</exception>
        public static T Modal<T>(this ModalSubmitInteractionContext context)
            where T : Modal, new()
        {
            lock (_lock)
            {
                var obj = new T();

                var index = context.Interaction.Data.CustomId.IndexOf(':');

                var info = _modalCache.Value[context.Interaction.Data.CustomId[..index]];

                if (info.Inputs.Length != context.Components.Count)
                    throw new ArgumentOutOfRangeException(nameof(context), $"The cached modalInfo length does not match the received component length.");

                for (int i = 0; i < info.Inputs.Length; i++)
                    info.Inputs[i].Property.SetValue(obj, context.Components[i]);

                return obj;
            }
        }
    }
}
