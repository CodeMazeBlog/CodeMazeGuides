namespace FlatteningNestedCollectionInCSharp.Models;

public record DepartmentFlattened
{
    public string DepartmentName { get; set; }
    public string EmployeeName { get; set; }
    public string EmployeeEmail { get; set; }
}