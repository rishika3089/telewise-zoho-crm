using Telewise.Api.Domain.Entities;

namespace Telewise.Api.Features.CRM.Repositories;

public interface ICrmEventRepository
{
    Task SaveAsync(
        CrmEvent crmEvent,
        CancellationToken cancellationToken = default);
}