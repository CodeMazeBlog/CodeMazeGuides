using System.Text;

namespace MultipleTasksDemo.Client.Extensions;

public static class EmployeeProfileExtensions
{
    public static void Display(this EmployeeProfile employeeProfile)
    {
        //To show euro sign
        Console.OutputEncoding = Encoding.Default;
        Console.WriteLine(employeeProfile.ToString());
    }
}
