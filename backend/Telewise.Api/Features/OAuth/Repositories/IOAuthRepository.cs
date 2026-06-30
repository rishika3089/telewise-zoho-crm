using Telewise.Api.Domain.Entities;

namespace Telewise.Api.Features.OAuth.Repositories;

public interface IOAuthRepository
{
    Task SaveAsync(
        OAuthToken token,
        CancellationToken cancellationToken = default);

    Task<OAuthToken?> GetAsync(
        CancellationToken cancellationToken = default);
}