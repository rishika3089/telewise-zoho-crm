namespace Telewise.Api.Features.CRM.DTOs;

public sealed class CrmEventRequest
{
    public string EventType { get; set; } = string.Empty;

    public string Payload { get; set; } = string.Empty;
}