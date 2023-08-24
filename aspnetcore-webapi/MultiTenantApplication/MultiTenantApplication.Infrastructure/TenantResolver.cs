namespace MultiTenantApplication.Infrastructure;

public class TenantResolver : ITenantResolver
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ITenantRegistry _tenantRegistry;

    public TenantResolver(IHttpContextAccessor httpContextAccessor, ITenantRegistry tenantRegistry)
    {
        _httpContextAccessor = httpContextAccessor;
        _tenantRegistry = tenantRegistry;
    }

    public Tenant GetCurrentTenant()
    {
        var claim = _httpContextAccessor.HttpContext.User.Claims
            .FirstOrDefault(e => e.Type == ClaimConstants.TenantId);

        if (claim is null)
            throw new UnauthorizedAccessException("Authentication failed");

        var tenant = _tenantRegistry.GetTenants().FirstOrDefault(t => t.Name == claim.Value);
        if (tenant is null)
            throw new UnauthorizedAccessException($"Tenant '{claim.Value}' is not registered.");

        return tenant;
    }
}