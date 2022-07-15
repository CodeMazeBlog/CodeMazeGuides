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
    public IActionResult Login([FromBody] User user)
    {
        if (user is null) 
            return BadRequest();

        var tenant = _tenantRegistry.Tenants.FirstOrDefault(e => e.Name == user.UserName && e.Secret == user.Password);

        if (tenant is null)
            return Unauthorized($"Invalid user");

        var tokenString = JwtHelper.GenerateToken(tenant);

        return Ok(new { Token = tokenString });
    }
}

public record class User(string UserName, string Password);