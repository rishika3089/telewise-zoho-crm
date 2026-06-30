using Telewise.Api.Domain.Entities;
using Telewise.Api.Features.Settings.DTOs;
using Telewise.Api.Features.Settings.Services.Interfaces;
using Telewise.Api.Infrastructure.Repositories;

namespace Telewise.Api.Features.Settings.Services.Implementations;
public sealed class SettingsService : ISettingsService
{
    private readonly ISettingsRepository _repository;

    public SettingsService(ISettingsRepository repository)
    {
        _repository = repository;
    }

    public async Task<SettingsDto> GetAsync(
        CancellationToken cancellationToken = default)
    {
        var settings = await _repository.GetAsync(cancellationToken);

        if (settings is null)
        {
            settings = new ApplicationSettings();
        }

        return new SettingsDto
        {
            NotificationsEnabled = settings.NotificationsEnabled,
            DefaultWebhook = settings.DefaultWebhook
        };
    }

    public async Task SaveAsync(
        UpdateSettingsRequest request,
        CancellationToken cancellationToken = default)
    {
        var settings = await _repository.GetAsync(cancellationToken);

        settings ??= new ApplicationSettings();

        settings.NotificationsEnabled = request.NotificationsEnabled;
        settings.DefaultWebhook = request.DefaultWebhook;
        settings.UpdatedAtUtc = DateTime.UtcNow;

        await _repository.SaveAsync(settings, cancellationToken);
    }
}