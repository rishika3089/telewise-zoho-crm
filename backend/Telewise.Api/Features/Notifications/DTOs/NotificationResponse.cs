namespace Telewise.Api.Features.Notifications.DTOs;

public sealed class NotificationResponse
{
    public string EventType { get; set; } = string.Empty;

    public string Destination { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public DateTime SentAtUtc { get; set; }
}