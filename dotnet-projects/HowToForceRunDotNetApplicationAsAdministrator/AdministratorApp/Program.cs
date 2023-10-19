using AdministratorApp;

public class Program
{
    static void Main()
    {
        var administratorChecker = new AdministratorChecker();
        bool isAdmin = administratorChecker.IsCurrentUserAdmin();
        PrivilegeStatusPrinter printer = new();
        printer.PrintPrivilegeStatus(isAdmin);

    }
}
