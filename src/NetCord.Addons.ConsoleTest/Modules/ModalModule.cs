using NetCord.Addons.Services.Interactions;
using NetCord.Addons.Tests.Console.Modules.Modals;
using NetCord.Services.ApplicationCommands;
using NetCord.Services.Interactions;

namespace NetCord.Addons.Tests.Console.Modules
{
    internal class ModalModule : InteractionModule<ModalSubmitInteractionContext>
    {
        [Interaction("my_customid")]
        public async Task ModalReceived()
        {
            var modal = Context.Modal<MyModal>();

            var input = modal.MyValue;
        }
    }

    internal class CommandModule : ApplicationCommandModule<SlashCommandContext>
    {
        [SlashCommand("command", "description")]
        public async Task SendModal()
        {
            await RespondAsync(InteractionCallback.Modal(new MyModal()));

            var modal = new MyModal();
            await RespondAsync(InteractionCallback.Modal(modal.ToModalProperties()));
        }
    }
}
