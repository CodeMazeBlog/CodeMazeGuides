namespace MultiTenantApplication.Core;

public class Tenant
{
    public string Name { get; set; } = null!;

    public string? ConnectionString { get; set; }
}