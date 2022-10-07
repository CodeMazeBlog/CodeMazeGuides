namespace ActionAndFunctionDelegates;
public class Program
{
    public static EmployeeModel employeeModel = new EmployeeModel();
    public static void Main()
    {
        System.Console.WriteLine(
            $"Total Employee Salary is: {employeeModel.calculateEmployeeSalary(162, printOverTimeAmount, printTotalSalaryAmount):C2}");
    }
    public static decimal printTotalSalaryAmount(decimal totalSalaryAmount)
    {
        return totalSalaryAmount;
    }

    public static void printOverTimeAmount(decimal overTimeAmount)
    {
        System.Console.WriteLine($"Total over Time Amount is {overTimeAmount:C2}");
    }
}
public class EmployeeModel
{

    // These properties could be comming from db config or converted to variables to suit different types and/or levels of each employee
    private static decimal ratePerHour = 150.00M;
    private static int totalStandardWorkingHours = 160;
    private static decimal overTimeRateOnStandardRatePerhour = 0.5M;
    public decimal calculateEmployeeSalary(decimal hoursWorked, Action<decimal> overTimeAmount,
                                            Func<decimal, decimal> totalSalaryAmount)
    {
        var employeeOverTimeAmount = 0.00M;
        var totalSalary = ratePerHour * hoursWorked;
        if (hoursWorked > totalStandardWorkingHours)
        {
            totalSalary = ratePerHour * totalStandardWorkingHours;
            totalSalary += employeeOverTimeAmount
                        = (ratePerHour + (ratePerHour * overTimeRateOnStandardRatePerhour))
                        * (hoursWorked - totalStandardWorkingHours);
        }
        overTimeAmount(employeeOverTimeAmount);
        return totalSalaryAmount(totalSalary);

    }

}