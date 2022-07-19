namespace MultiTenantApplication.Core;

#nullable disable

public class TenantOptions
{
    public string DefaultConnection { get; set; }

    public Tenant[] Tenants { get; set; }
}