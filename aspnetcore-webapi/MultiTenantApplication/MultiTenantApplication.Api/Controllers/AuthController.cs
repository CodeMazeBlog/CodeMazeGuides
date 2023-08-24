namespace MultiTenantApplication.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly ITenantRegistry _tenantRegistry;

    public AuthController(ITenantRegistry tenantRegistry)
    {
        _tenantRegistry = tenantRegistry;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest loginRequest)
    {
        if (loginRequest is null) 
            return BadRequest();

        var user = _tenantRegistry.GetUsers()
            .FirstOrDefault(e => e.Name == loginRequest.UserName && e.Secret == loginRequest.Password);

        if (user is null)
            return Unauthorized($"Invalid user");

        if (_tenantRegistry.GetTenants().FirstOrDefault(e => e.Name == user.TenantId) is not { } tenant)
            return Unauthorized($"Invalid tenant");

        var tokenString = JwtHelper.GenerateToken(tenant);

        return Ok(new { Token = tokenString });
    }
}