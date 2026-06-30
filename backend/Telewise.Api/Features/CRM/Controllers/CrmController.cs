using Microsoft.AspNetCore.Mvc;
using Telewise.Api.Features.CRM.DTOs;
using Telewise.Api.Features.CRM.Services;

namespace Telewise.Api.Features.CRM.Controllers;

[ApiController]
[Route("crm")]
public sealed class CrmController : ControllerBase
{
    private readonly ICrmEventService _service;

    public CrmController(ICrmEventService service)
    {
        _service = service;
    }

    [HttpPost("events")]
    public async Task<IActionResult> Receive(
        CrmEventRequest request,
        CancellationToken cancellationToken)
    {
        await _service.ReceiveAsync(
            request,
            cancellationToken);

        return Ok(new
        {
            Message = "CRM Event received successfully."
        });
    }
}