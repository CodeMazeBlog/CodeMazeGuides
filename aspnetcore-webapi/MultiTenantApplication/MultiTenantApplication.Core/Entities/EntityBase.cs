namespace MultiTenantApplication.Core.Entities;

public abstract class EntityBase
{
    public int Id { get; set; }

    public string TenantId { get; set; } = null!;
}