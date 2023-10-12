using System;
using System.Security.Principal;

public class AdministratorChecker : IAdministratorChecker
{
    public bool IsCurrentUserAdmin()
    {
        using (var identity = WindowsIdentity.GetCurrent())
        {
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
