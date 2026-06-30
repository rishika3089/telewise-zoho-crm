using Telewise.Api.Features.OAuth.DTOs;

namespace Telewise.Api.Features.OAuth.Services;

public interface IOAuthService
{
    Task<string> BuildAuthorizationUrlAsync();

    Task<OAuthTokenResponse> ExchangeCodeAsync(
        string code,
        CancellationToken cancellationToken = default);
}