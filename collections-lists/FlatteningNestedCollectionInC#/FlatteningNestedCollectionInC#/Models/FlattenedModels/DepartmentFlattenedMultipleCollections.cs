namespace FlatteningNestedCollectionInCSharp.Models;

public record DepartmentFlattenedMultipleCollections
{
    public string DepartmentName { get; set; }
    public string EmployeeName { get; set; }
    public string EmployeeEmail { get; set; }
    public string ProjectTitle { get; set; }
    public int ProjectBudget { get; set; }
}