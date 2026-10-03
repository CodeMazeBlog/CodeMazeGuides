namespace DIP.Statistics;

public sealed class EmployeeStatistics(IEmployeeSearchable employees)
{
    public int CountFemaleManagers() =>
        employees.GetEmployeesByGenderAndPosition(Gender.Female, Position.Manager).Count();
}
