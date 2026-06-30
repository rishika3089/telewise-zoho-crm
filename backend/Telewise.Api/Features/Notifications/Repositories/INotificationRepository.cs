using Telewise.Api.Domain.Entities;

namespace Telewise.Api.Features.Notifications.Repositories;

public interface INotificationRepository
{
    Task SaveAsync(
        NotificationLog notification,
        CancellationToken cancellationToken = default);

    Task<List<NotificationLog>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task UpdateAsync(
        NotificationLog notification,
        CancellationToken cancellationToken = default);
}