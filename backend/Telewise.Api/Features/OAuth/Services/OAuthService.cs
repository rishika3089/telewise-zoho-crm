using System.Web;
using Microsoft.Extensions.Options;
using Telewise.Api.Configuration;
using Telewise.Api.Domain.Entities;
using Telewise.Api.Features.OAuth.Clients;
using Telewise.Api.Features.OAuth.DTOs;
using Telewise.Api.Features.OAuth.Repositories;

namespace Telewise.Api.Features.OAuth.Services;

public sealed class OAuthService : IOAuthService
{
    private readonly ZohoOptions _options;
    private readonly ZohoOAuthClient _client;
    private readonly IOAuthRepository _repository;

    public OAuthService(
        IOptions<ZohoOptions> options,
        ZohoOAuthClient client,
        IOAuthRepository repository)
    {
        _options = options.Value;
        _client = client;
        _repository = repository;
    }

    public Task<string> BuildAuthorizationUrlAsync()
    {
        var builder = new UriBuilder(
            $"{_options.AccountsBaseUrl}/oauth/v2/auth");

        var query = HttpUtility.ParseQueryString(string.Empty);

        query["response_type"] = "code";
        query["client_id"] = _options.ClientId;
        query["scope"] = _options.Scope;
        query["redirect_uri"] = _options.RedirectUri;
        query["access_type"] = _options.AccessType;
        query["prompt"] = _options.Prompt;

        builder.Query = query.ToString();

        return Task.FromResult(builder.ToString());
    }

    public async Task<OAuthTokenResponse> ExchangeCodeAsync(
        string code,
        CancellationToken cancellationToken = default)
    {
        var response = await _client.ExchangeCodeAsync(
            code,
            cancellationToken);

        var token = new OAuthToken
        {
            AccessToken = response.AccessToken,
            RefreshToken = response.RefreshToken,
            TokenType = response.TokenType,
            ApiDomain = response.ApiDomain,
            ExpiresAtUtc = DateTime.UtcNow.AddSeconds(response.ExpiresIn)
        };

        await _repository.SaveAsync(
            token,
            cancellationToken);

        return response;
    }
}