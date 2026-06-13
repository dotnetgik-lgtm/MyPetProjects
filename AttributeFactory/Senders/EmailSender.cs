using Microsoft.Extensions.Logging;

namespace AttributeFactory.Senders;

[ProductKey("email")]
public class EmailSender : INotificationSender
{
    private readonly ILogger<EmailSender> _logger;

    public EmailSender(ILogger<EmailSender> logger) => _logger = logger;

    public void Send(string message) =>
        _logger.LogInformation("[EMAIL] {Message}", message);
}
