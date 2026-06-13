using Microsoft.Extensions.Logging;

namespace AttributeFactory.Senders;

[ProductKey("slack")]
public class SlackSender : INotificationSender
{
    
    private readonly ILogger<SlackSender> _logger;

    public SlackSender(ILogger<SlackSender> logger) => _logger = logger;

    public void Send(string message) =>
        _logger.LogInformation("[SLACK] {Message}", message);
}
