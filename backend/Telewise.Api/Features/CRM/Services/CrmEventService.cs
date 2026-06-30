using Telewise.Api.Domain.Entities;
using Telewise.Api.Features.CRM.DTOs;
using Telewise.Api.Features.CRM.Repositories;
using Telewise.Api.Features.Notifications.Services;

namespace Telewise.Api.Features.CRM.Services;

public sealed class CrmEventService : ICrmEventService
{
    private readonly ICrmEventRepository _repository;
    private readonly INotificationService _notificationService;

    public CrmEventService(
        ICrmEventRepository repository,
        INotificationService notificationService)
    {
        _repository = repository;
        _notificationService = notificationService;
    }

    public async Task ReceiveAsync(
        CrmEventRequest request,
        CancellationToken cancellationToken = default)
    {
        var crmEvent = new CrmEvent
        {
            EventType = request.EventType,
            Payload = request.Payload,
            ReceivedAtUtc = DateTime.UtcNow
        };

        await _repository.SaveAsync(
            crmEvent,
            cancellationToken);

        await _notificationService.CreateAsync(
            request.EventType,
            request.Payload,
            cancellationToken);
    }
}