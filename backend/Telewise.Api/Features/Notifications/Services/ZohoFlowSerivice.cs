using System.Net.Http.Json;
using Telewise.Api.Features.Settings.Services.Interfaces;

namespace Telewise.Api.Features.Notifications.Services;

public sealed class ZohoFlowService : IZohoFlowService
{
    private readonly HttpClient _httpClient;
    private readonly ISettingsService _settingsService;

    public ZohoFlowService(
        HttpClient httpClient,
        ISettingsService settingsService)
    {
        _httpClient = httpClient;
        _settingsService = settingsService;
    }

    public async Task<bool> SendAsync(
        string eventType,
        string payload,
        CancellationToken cancellationToken = default)
    {
        var settings =
            await _settingsService.GetAsync(cancellationToken);

        if (string.IsNullOrWhiteSpace(settings.DefaultWebhook))
            return false;

        var response = await _httpClient.PostAsJsonAsync(
            settings.DefaultWebhook,
            new
            {
                EventType = eventType,
                Payload = payload
            },
            cancellationToken);

        return response.IsSuccessStatusCode;
    }
}