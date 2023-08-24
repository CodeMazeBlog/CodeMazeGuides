namespace MultiTenantApplication.Core.Abstractions;

public interface ITenantResolver
{
    Tenant GetCurrentTenant();
}