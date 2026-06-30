using Telewise.Api.Features.Settings.DTOs;

namespace Telewise.Api.Features.Settings.Services.Interfaces;

public interface ISettingsService
{
    Task<SettingsDto> GetAsync(
        CancellationToken cancellationToken = default);

    Task SaveAsync(
        UpdateSettingsRequest request,
        CancellationToken cancellationToken = default);
}