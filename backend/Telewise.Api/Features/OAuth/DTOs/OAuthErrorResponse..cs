using System.Text.Json.Serialization;

namespace Telewise.Api.Features.OAuth.DTOs;

public sealed class OAuthErrorResponse
{
    [JsonPropertyName("error")]
    public string Error { get; set; } = string.Empty;
}