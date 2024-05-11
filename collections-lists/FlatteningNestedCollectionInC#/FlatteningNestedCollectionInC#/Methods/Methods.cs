using FlatteningNestedCollection.Models;

namespace FlatteningNestedCollection;

public class Methods
{
    public static IEnumerable<object> FlattenWithSelect(Department department)
    {
        return department?.Employees?.Select(employee => new
        {
            department.DepartmentName,
            employee.EmployeeName,
            employee.EmployeeEmail
        });
    }

    public static IEnumerable<object> FlattenWithQueryExpression(Department department)
    {
        return from employee in department?.Employees ?? Enumerable.Empty<Employee>()
            select new
            {
                department.DepartmentName,
                employee.EmployeeName,
                employee.EmployeeEmail
            };
    }

    public static IEnumerable<object> FlattenWithSelectMany(Department department)
    {
        return department?.Employees?.SelectMany(
            employee => department.Projects.Select(project => new
            {
                department.DepartmentName,
                employee.EmployeeName,
                employee.EmployeeEmail,
                project.ProjectTitle,
                project.Budget
            })
        );
    }

    public static IEnumerable<object> FlattenComplexWithSelectMany(Department department)
    {
        return department?.Employees?.SelectMany(
            employee => employee.Certifications?.Select(certification => new
            {
                department.DepartmentName,
                employee.EmployeeName,
                employee.EmployeeEmail,
                certification.Title,
                certification.IssueDate
            })
        );
    }
}
