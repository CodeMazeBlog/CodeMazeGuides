using MultipleTasksDemo.Client.Contracts;

namespace MultipleTasksDemo.Client.Extensions;

public static class EmployeeDetailsExtensions
{
    public static void Display(this IEnumerable<EmployeeDetails> employeeDetails)
    {
        foreach (var employeeDetail in employeeDetails)
        {
            Console.WriteLine($"Id: {employeeDetail.Id}\nName: {employeeDetail.Name}\nDOB: {employeeDetail.DateOfBirth}\n");
        }
    }
}
