using Microsoft.AspNetCore.Mvc;
using Telewise.Api.Features.OAuth.DTOs;
using Telewise.Api.Features.OAuth.Services;

namespace Telewise.Api.Features.OAuth.Controllers;

[ApiController]
[Route("oauth")]
public sealed class OAuthController : ControllerBase
{
    private readonly IOAuthService _service;

    public OAuthController(IOAuthService service)
    {
        _service = service;
    }

    [HttpGet("login")]
    public async Task<ActionResult<OAuthAuthorizationResponse>> Login()
    {
        var url = await _service.BuildAuthorizationUrlAsync();

        return Ok(new OAuthAuthorizationResponse
        {
            AuthorizationUrl = url
        });
    }

    [HttpGet("callback")]
public async Task<IActionResult> Callback(
    [FromQuery] string code,
    CancellationToken cancellationToken)
{
    await _service.ExchangeCodeAsync(
        code,
        cancellationToken);

    return Ok(new
    {
        message = "OAuth authentication completed successfully."
    });
}
}