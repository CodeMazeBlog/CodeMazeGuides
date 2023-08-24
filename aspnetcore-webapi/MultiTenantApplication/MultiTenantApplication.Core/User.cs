namespace MultiTenantApplication.Core;

public class User
{
    public string Name { get; set; } = null!;

    public string Secret { get; set; } = null!;

    public string TenantId { get; set; } = null!;
}