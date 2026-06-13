using AttributeFactory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var services = new ServiceCollection()
    .AddLogging(b => b.AddConsole().SetMinimumLevel(LogLevel.Information))
    .AddAttributeFactory<INotificationSender>()
    .BuildServiceProvider();

var factory = services.GetRequiredService<AttributeFactory<INotificationSender>>();

Console.WriteLine($"Registered channels: {string.Join(", ", factory.RegisteredKeys)}\n");

foreach (var channel in new[] { "email", "sms", "push" })
{
    var sender = factory.Create(channel);
    sender.Send($"Hello from the {channel} channel!");
}

Console.WriteLine("\nDone. Press any key to exit.");
Console.ReadKey();
