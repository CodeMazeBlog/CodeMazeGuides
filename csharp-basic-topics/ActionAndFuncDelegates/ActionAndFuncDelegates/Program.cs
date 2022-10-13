using EmloyeeModel;

namespace ActionAndFunctionDelegates;
public class Program
{
    public static EmployeeModel employeeModel = new EmployeeModel();

    public static void Main()
    {
        System.Console.WriteLine(
            $"Total Employee Salary is: {employeeModel.CalculateEmployeeSalary(162, PrintOverTimeAmount, PrintTotalSalaryAmount):C2}");
    }

    public static decimal PrintTotalSalaryAmount(decimal totalSalaryAmount)
    {

        return totalSalaryAmount;
    }

    public static void PrintOverTimeAmount(decimal overTimeAmount)
    {
        System.Console.WriteLine($"Total over Time Amount is {overTimeAmount:C2}");
    }
}
