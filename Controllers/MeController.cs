using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class MeController : ControllerBase
{
    private readonly ILogger<MeController> _logger;

    public MeController(ILogger<MeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("GetMe")]
    [Authorize] // Requires a valid JWT Bearer token
    public IActionResult GetMe()
    {
        try
        {
            var user = HttpContext.User;

            if (user?.Identity == null || !user.Identity.IsAuthenticated)
                return Unauthorized();

            var name = user.FindFirst("name")?.Value ?? user.FindFirst(ClaimTypes.Name)?.Value;
            var email = user.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn")?.Value;
            var roles = user.FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value;
            var scopes = user.FindFirst("http://schemas.microsoft.com/identity/claims/scope")?.Value;
           // var allClaims = user.Claims.Select(c => new { c.Type, c.Value }).ToList();

            return Ok(new
            {
                name,
                email,
                roles,
                scopes,
             //   allClaims
            });
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "An error occurred in GetMe");
            return StatusCode(500, "An unexpected error occurred. Please contact support.");
        }
        
    }
}
