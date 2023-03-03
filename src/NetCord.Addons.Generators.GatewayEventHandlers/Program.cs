using NetCord.Gateway;

Console.WriteLine("Define the route to gen the classes in.");
var route = Console.ReadLine() ?? throw new NullReferenceException();

if (Directory.Exists(route))
    Directory.Delete(route, true);

Directory.CreateDirectory(route);

var events = typeof(GatewayClient).GetEvents();

Console.WriteLine(events.Length);

foreach (var e in events)
{
    var funcInfo = e.EventHandlerType!;

    var generics = funcInfo.GenericTypeArguments[..^1];

    Console.WriteLine($"Generics length: {generics.Length}");
    var inputs = new List<string>();

    for (int i = 0; i < generics.Length; i++)
    {
        inputs.Add($"{generics[i].Name} eventArgs");
    }

    var arguments = "";
    if (inputs.Any())
        arguments = string.Join(", ", inputs);

    var code = new[]
    {
        "using NetCord.Gateway;",
        "",
        "namespace NetCord.Addons.Hosting",
        "{",
        "   /// <summary>",
       $"   ///     Represents an event handler that is responsible for handling the <see cref=\"GatewayClient.{e.Name}\"/> event.",
        "   /// </summary>",
       $"   public abstract class {e.Name}Handler : GatewayEventHandler",
        "   {",
        "       /// <summary>",
       $"       ///     Creates a new <see cref=\"{e.Name}Handler\"/> to handle the {e.Name} event.",
        "       /// </summary>",
        "       /// <param name=\"client\">The <see cref=\"GatewayClient\"/> used to register this event handler.</param>",
       $"       protected {e.Name}Handler(GatewayClient client) : base(client) {{ }}",
        "       ",
        "       /// <inheritdoc />",
       $"       public abstract ValueTask HandleAsync({arguments});",
        "       ",
        "       /// <inheritdoc />",
        "       public override void Subscribe()",
       $"           => Client.{e.Name} += HandleAsync;",
        "       ",
        "       /// <inheritdoc />",
        "       public override void UnSubscribe()",
       $"           => Client.{e.Name} -= HandleAsync;",
        "   }",
        "}"
    };

    File.WriteAllText(Path.Combine(route, $"{e.Name}Handler.cs"), string.Join("\n", code));
}