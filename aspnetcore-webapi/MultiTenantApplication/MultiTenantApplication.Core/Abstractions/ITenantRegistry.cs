namespace MultiTenantApplication.Core.Abstractions;

public interface ITenantRegistry
{
    Tenant[] Tenants { get; }
}