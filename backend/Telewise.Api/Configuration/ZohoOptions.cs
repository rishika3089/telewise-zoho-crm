namespace Telewise.Api.Configuration;

public sealed class ZohoOptions
{
    public const string SectionName = "Zoho";

    public string ClientId { get; set; } = string.Empty;

    public string ClientSecret { get; set; } = string.Empty;

    public string RedirectUri { get; set; } = string.Empty;

    public string AccountsBaseUrl { get; set; } = "https://accounts.zoho.in";

    public string ApiBaseUrl { get; set; } = "https://www.zohoapis.in";

    public string Scope { get; set; } =
        "ZohoCRM.modules.ALL,ZohoCRM.settings.ALL";

    public string AccessType { get; set; } = "offline";

    public string Prompt { get; set; } = "consent";
}