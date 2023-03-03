using NetCord.Gateway;

Console.WriteLine("Define the route to gen the classes in.");
var route = Console.ReadLine() ?? throw new NullReferenceException();

if (Directory.Exists(route))
    Directory.Delete(route, true);

Directory.CreateDirectory(route);

var events = typeof(GatewayClient).GetEvents();

foreach (var e in events)
{
    var generics = e.EventHandlerType!.GenericTypeArguments[..^1];

    var arguments = "";
    if (generics.Any())
        arguments = $"{generics[0].Name} eventArgs";

    var code =
        $$"""
        using NetCord.Gateway;

        namespace NetCord.Addons.Hosting
        {
            /// <summary>
            ///     Represents an event handler that is responsible for handling the <see cref="GatewayClient.{{e.Name}}"/> event.
            /// </summary>
            public abstract class {{e.Name}}Handler : GatewayEventHandler
            {
                /// <summary>
                ///     Creates a new <see cref="{{e.Name}}Handler"/> to handle the {{e.Name}} event.
                /// </summary>
                /// <param name="client">The <see cref="GatewayClient"/> used to register this event handler.</param>
                protected {{e.Name}}Handler(GatewayClient client) : base(client) { }

                /// <inheritdoc />
                public abstract ValueTask HandleAsync({{arguments}});

                /// <inheritdoc />
                public override void Subscribe()
                    => Client.{{e.Name}} += HandleAsync;

                /// <inheritdoc />
                public override void UnSubscribe()
                    => Client.{{e.Name}} -= HandleAsync;
            }
        }
        """;

    File.WriteAllText(Path.Combine(route, $"{e.Name}Handler.cs"), code);
}