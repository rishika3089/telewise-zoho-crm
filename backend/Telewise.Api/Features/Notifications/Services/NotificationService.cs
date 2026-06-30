using Telewise.Api.Domain.Entities;
using Telewise.Api.Features.Notifications.DTOs;
using Telewise.Api.Features.Notifications.Repositories;

namespace Telewise.Api.Features.Notifications.Services;

public sealed class NotificationService : INotificationService
{
    private readonly INotificationRepository _repository;
    private readonly IZohoFlowService _zohoFlowService;

    public NotificationService(
        INotificationRepository repository,
        IZohoFlowService zohoFlowService)
    {
        _repository = repository;
        _zohoFlowService = zohoFlowService;
    }

    public async Task CreateAsync(
        string eventType,
        string payload,
        CancellationToken cancellationToken = default)
    {
        var notification = new NotificationLog
        {
            EventType = eventType,
            Destination = "Zoho Flow",
            Status = "Pending",
            Payload = payload,
            SentAtUtc = DateTime.UtcNow
        };

        await _repository.SaveAsync(
            notification,
            cancellationToken);

        var sent = await _zohoFlowService.SendAsync(
            eventType,
            payload,
            cancellationToken);

        notification.Status = sent
            ? "Sent"
            : "Failed";

        await _repository.UpdateAsync(
            notification,
            cancellationToken);
    }

    public async Task<List<NotificationResponse>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var notifications =
            await _repository.GetAllAsync(
                cancellationToken);

        return notifications
            .Select(x => new NotificationResponse
            {
                EventType = x.EventType,
                Destination = x.Destination,
                Status = x.Status,
                SentAtUtc = x.SentAtUtc
            })
            .ToList();
    }
}