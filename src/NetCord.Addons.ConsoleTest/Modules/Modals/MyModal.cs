using NetCord.Addons.Services.Interactions;
using NetCord.Rest;

namespace NetCord.Addons.Tests.Console.Modules.Modals
{
    internal class MyModal : Modal
    {
        public override string CustomId
            => "my_customId";

        public override string Title
            => "This is my Modal";

        [Label("A label")]
        [CustomId("a_custom_id")]
        [Style(TextInputStyle.Short)]
        [InputRestriction(isRequired: true)]
        public string MyValue { get; set; } = string.Empty;
    }
}
