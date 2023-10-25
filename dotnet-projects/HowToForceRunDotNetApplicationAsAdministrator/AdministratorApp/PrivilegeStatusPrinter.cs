namespace AdministratorApp
{
    public static class PrivilegeStatusPrinter
    {
        public static void PrintPrivilegeStatus(bool isAdmin)
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
}
