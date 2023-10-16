using AdministratorApp;

public class Program
{
    static void Main()
    {
        IAdministratorChecker administratorChecker = new AdministratorChecker();
        bool isAdmin = administratorChecker.IsCurrentUserAdmin();
        PrivilegeStatusPrinter printer = new();
        printer.PrintPrivilegeStatus(isAdmin);

    }
}
