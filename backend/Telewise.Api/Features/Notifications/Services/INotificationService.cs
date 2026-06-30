using Telewise.Api.Features.Notifications.DTOs;

namespace Telewise.Api.Features.Notifications.Services;

public interface INotificationService
{
    Task CreateAsync(
        string eventType,
        string payload,
        CancellationToken cancellationToken = default);

    Task<List<NotificationResponse>> GetAllAsync(
        CancellationToken cancellationToken = default);
}