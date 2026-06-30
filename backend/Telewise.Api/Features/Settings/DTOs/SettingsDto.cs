namespace Telewise.Api.Features.Settings.DTOs;

public sealed class SettingsDto
{
    public bool NotificationsEnabled { get; set; }

    public string DefaultWebhook { get; set; } = string.Empty;
}