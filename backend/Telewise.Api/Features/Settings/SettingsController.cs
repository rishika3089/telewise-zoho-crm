using Microsoft.AspNetCore.Mvc;
using Telewise.Api.Features.Settings.DTOs;
using Telewise.Api.Features.Settings.Services.Interfaces;
namespace Telewise.Api.Features.Settings;
[ApiController]
[Route("settings")]
public sealed class SettingsController : ControllerBase
{
    private readonly ISettingsService _service;

    public SettingsController(ISettingsService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<SettingsDto>> Get(
        CancellationToken cancellationToken)
    {
        var result = await _service.GetAsync(cancellationToken);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Save(
        UpdateSettingsRequest request,
        CancellationToken cancellationToken)
    {
        await _service.SaveAsync(request, cancellationToken);

        return NoContent();
    }
}