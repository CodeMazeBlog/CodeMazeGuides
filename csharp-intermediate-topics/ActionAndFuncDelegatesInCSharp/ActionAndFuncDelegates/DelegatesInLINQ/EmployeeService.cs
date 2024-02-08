namespace DelegatesInLINQ;

public class EmployeeService
{
    public static int GetActiveEmployeesCount(IEnumerable<Employee> employees) => employees.Count(emp => emp.IsActive);
}
