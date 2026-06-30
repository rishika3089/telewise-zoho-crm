namespace Telewise.Api.Features.Notifications.Services;

public interface IZohoFlowService
{
    Task<bool> SendAsync(
        string eventType,
        string payload,
        CancellationToken cancellationToken = default);
}