using Microsoft.AspNetCore.DataProtection;

namespace WebApiBestPractices.Api.Security;

public class OwnerIdProtector(IDataProtectionProvider provider)
{
    private readonly IDataProtector _protector = provider.CreateProtector("WebApiBestPractices.OwnerIds");

    public string Protect(Guid ownerId) => _protector.Protect(ownerId.ToString());

    public Guid Unprotect(string protectedId) => Guid.Parse(_protector.Unprotect(protectedId));
}
