using MultiTenantApplication.Core.Abstractions;

namespace MultiTenantApplication.Core.Entities;

#nullable disable

public class Goods : IHaveTenant
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string TenantId { get; set; }
}