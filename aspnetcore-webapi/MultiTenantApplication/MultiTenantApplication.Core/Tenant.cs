namespace MultiTenantApplication.Core;

#nullable disable

public class Tenant
{
    public string Name { get; set; }
    public string Secret { get; set; }
    public string ConnectionString { get; set; }
}