using System.Security.Principal;

public class AdministratorChecker : IAdministratorChecker
{
    public bool IsCurrentUserAdmin()
    {
        WindowsIdentity identity = WindowsIdentity.GetCurrent();
        var principal = new WindowsPrincipal(identity);
        return principal.IsInRole(WindowsBuiltInRole.Administrator);
    }
}
