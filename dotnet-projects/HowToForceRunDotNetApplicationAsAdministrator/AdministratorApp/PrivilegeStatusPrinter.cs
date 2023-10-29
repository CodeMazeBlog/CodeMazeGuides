namespace AdministratorApp;

public static class PrivilegeStatusPrinter
{
    public static void Print(bool isAdmin)
    {
        if (isAdmin)
        {
            Console.WriteLine("The application is running with administrator privileges.");
        }
        else
        {
            Console.WriteLine("The application is not running with administrator privileges.");
        }
    }
}