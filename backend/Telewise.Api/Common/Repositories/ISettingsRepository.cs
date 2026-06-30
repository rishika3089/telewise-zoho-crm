using Telewise.Api.Domain.Entities;

namespace Telewise.Api.Infrastructure.Repositories;

public interface ISettingsRepository
{
    Task<ApplicationSettings?> GetAsync(
        CancellationToken cancellationToken = default);

    Task SaveAsync(
        ApplicationSettings settings,
        CancellationToken cancellationToken = default);
}