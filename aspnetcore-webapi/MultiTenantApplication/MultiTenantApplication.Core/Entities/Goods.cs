namespace MultiTenantApplication.Core.Entities;

public class Goods : EntityBase
{
    public string Name { get; set; } = null!;

    public decimal Price { get; set; }
}