using Telewise.Api.Features.CRM.DTOs;

namespace Telewise.Api.Features.CRM.Services;

public interface ICrmEventService
{
    Task ReceiveAsync(
        CrmEventRequest request,
        CancellationToken cancellationToken = default);
}