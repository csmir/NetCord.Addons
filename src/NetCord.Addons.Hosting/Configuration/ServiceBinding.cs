namespace NetCord.Addons.Hosting
{
    [Flags]
    public enum ServiceBinding : byte
    {
        None = 1,

        TextCommand = 2,

        SlashCommand = 4,

        UserCommand = 8,

        MessageCommand = 16,

        ModalInteraction = 32,

        ButtonInteraction = 64,

        SelectMenuInteraction = 128,
    }
}
