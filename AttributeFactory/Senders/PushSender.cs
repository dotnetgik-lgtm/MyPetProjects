using Microsoft.Extensions.Logging;

namespace AttributeFactory.Senders;

[ProductKey("push")]
public class PushSender : INotificationSender
{
    private readonly ILogger<PushSender> _logger;

    public PushSender(ILogger<PushSender> logger) => _logger = logger;

    public void Send(string message) =>
        _logger.LogInformation("[PUSH] {Message}", message);
}
