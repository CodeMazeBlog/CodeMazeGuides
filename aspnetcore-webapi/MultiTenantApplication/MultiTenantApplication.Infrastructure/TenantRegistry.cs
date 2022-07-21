namespace MultiTenantApplication.Infrastructure;

public class TenantRegistry : ITenantRegistry
{
    private readonly TenantOptions _registry;

    public TenantRegistry(IConfiguration configuration)
    {
        _registry = configuration.GetSection("TenantOptions").Get<TenantOptions>();

        foreach(var tenant in _registry.Tenants.Where(e => string.IsNullOrEmpty(e.ConnectionString)))
        {
            tenant.ConnectionString = _registry.DefaultConnection;
        }
    }

    public Tenant[] GetTenants() => _registry.Tenants;

    public User[] GetUsers() => _registry.Users;
}