using Microsoft.Extensions.Logging;

namespace AttributeFactory.Senders;

[ProductKey("sms")]
public class SmsSender : INotificationSender
{
    private readonly ILogger<SmsSender> _logger;

    public SmsSender(ILogger<SmsSender> logger) => _logger = logger;

    public void Send(string message) =>
        _logger.LogInformation("[SMS] {Message}", message);
}
