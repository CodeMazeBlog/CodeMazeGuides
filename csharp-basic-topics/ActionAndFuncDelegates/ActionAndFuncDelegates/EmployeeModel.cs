namespace EmloyeeModel;

public class EmployeeModel
{

    private static decimal ratePerHour = 150.00M;
    private static int totalStandardWorkingHours = 160;
    private static decimal overTimeRateOnStandardRatePerhour = 0.5M;

    public decimal CalculateEmployeeSalary(decimal hoursWorked, Action<decimal> overTimeAmount,
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
