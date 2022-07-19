namespace MultiTenantApplication.Core.Abstractions;

public interface IHaveTenant
{
    public string TenantId { get; set; }
}