namespace Telewise.Api.Configuration;

public sealed class NotificationOptions
{
    public const string SectionName = "Notifications";

    public string DefaultWebhook { get; set; } = string.Empty;

    public bool Enabled { get; set; } = true;
}