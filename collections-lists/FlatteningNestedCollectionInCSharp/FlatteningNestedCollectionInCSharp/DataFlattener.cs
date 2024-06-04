using FlatteningNestedCollectionInCSharp.Models;

namespace FlatteningNestedCollectionInCSharp;

public class DataFlattener
{
    public static IEnumerable<DepartmentFlattened> FlattenWithSelect(Department department)
    {
        return department?.Employees?.Select(employee => 
            new DepartmentFlattened(
                department.Name, 
                employee.Name, 
                employee.Email
                )
            );
    }

    public static IEnumerable<DepartmentFlattened> FlattenWithQueryExpression(Department department)
    {
        return from employee in department?.Employees ?? []
            select new DepartmentFlattened(department.Name, employee.Name, employee.Email);
    }

    public static IEnumerable<DepartmentFlattenedMultipleCollections>? FlattenWithSelectMany(Department department)
    {
        return department?.Employees?.SelectMany(
            employee => department.Projects.Select(project => new DepartmentFlattenedMultipleCollections(
                department.Name,
                employee.Name, 
                employee.Email,
                project.Title,
                project.Budget
                )
            )
        );
    }

    public static IEnumerable<DepartmentFlattenedComplex>? FlattenComplexWithSelectMany(Department department)
    {
        return department?.Employees?.SelectMany(
            employee => employee.Certifications?.Select(certification => new DepartmentFlattenedComplex(
                department.Name,
                employee.Name,
                employee.Email,
                certification.Title,
                certification.IssueDate
                )
            )
        );
    }
}
