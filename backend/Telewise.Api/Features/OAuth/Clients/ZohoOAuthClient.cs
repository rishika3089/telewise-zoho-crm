using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using Telewise.Api.Configuration;
using Telewise.Api.Features.OAuth.DTOs;

namespace Telewise.Api.Features.OAuth.Clients;

public sealed class ZohoOAuthClient
{
    private readonly HttpClient _httpClient;
    private readonly ZohoOptions _options;

    public ZohoOAuthClient(
        HttpClient httpClient,
        IOptions<ZohoOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;
    }

    public async Task<OAuthTokenResponse> ExchangeCodeAsync(
        string code,
        CancellationToken cancellationToken = default)
    {
        var values = new Dictionary<string, string>
        {
            ["grant_type"] = "authorization_code",
            ["client_id"] = _options.ClientId,
            ["client_secret"] = _options.ClientSecret,
            ["redirect_uri"] = _options.RedirectUri,
            ["code"] = code
        };

        using var content = new FormUrlEncodedContent(values);

        var response = await _httpClient.PostAsync(
            $"{_options.AccountsBaseUrl}/oauth/v2/token",
            content,
            cancellationToken);

        response.EnsureSuccessStatusCode();

        var token =
            await response.Content.ReadFromJsonAsync<OAuthTokenResponse>(
                cancellationToken: cancellationToken);

        return token ??
               throw new InvalidOperationException(
                   "Zoho returned an empty token response.");
    }
}