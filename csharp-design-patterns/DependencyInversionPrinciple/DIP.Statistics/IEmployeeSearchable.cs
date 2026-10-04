namespace DIP.Statistics;

public interface IEmployeeSearchable
{
    IEnumerable<Employee> GetEmployeesByGenderAndPosition(Gender gender, Position position);
}
