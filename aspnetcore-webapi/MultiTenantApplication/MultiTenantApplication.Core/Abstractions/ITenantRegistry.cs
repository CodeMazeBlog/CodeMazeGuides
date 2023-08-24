namespace MultiTenantApplication.Core.Abstractions;

public interface ITenantRegistry
{
    Tenant[] GetTenants();

    User[] GetUsers();
}