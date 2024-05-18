using FlatteningNestedCollection.Models;
using FlatteningNestedCollectionInCSharp.Models;

namespace FlatteningNestedCollection;

public class DataFlattenerMethods
{
    public static IEnumerable<DepartmentFlattened> FlattenWithSelect(Department department)
    {
        return department?.Employees?.Select(employee => new DepartmentFlattened()
        {
            DepartmentName = department.Name,
            EmployeeName = employee.Name,
            EmployeeEmail = employee.Email
        });
    }

    public static IEnumerable<DepartmentFlattened> FlattenWithQueryExpression(Department department)
    {
        return from employee in department?.Employees ?? []
            select new DepartmentFlattened()
            {
                DepartmentName = department.Name,
                EmployeeName = employee.Name,
                EmployeeEmail = employee.Email
            };
    }

    public static IEnumerable<DepartmentFlattenedMultipleCollections> FlattenWithSelectMany(Department department)
    {
        return department?.Employees?.SelectMany(
            employee => department.Projects.Select(project => new DepartmentFlattenedMultipleCollections()
            {
                DepartmentName = department.Name,
                EmployeeName = employee.Name,
                EmployeeEmail = employee.Email,
                ProjectTitle = project.Title,
                ProjectBudget = project.Budget
            })
        );
    }

    public static IEnumerable<DepartmentFlattenedComplex> FlattenComplexWithSelectMany(Department department)
    {
        return department?.Employees?.SelectMany(
            employee => employee.Certifications?.Select(certification => new DepartmentFlattenedComplex()
            {
                DepartmentName = department.Name,
                EmployeeName = employee.Name,
                EmployeeEmail = employee.Email,
                CertificationTitle = certification.Title,
                CertificationIssueDate = certification.IssueDate
            })
        );
    }
}
