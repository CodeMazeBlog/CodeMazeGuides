namespace FlatteningNestedCollectionInCSharp.Models;

public record DepartmentFlattenedComplex
{
    public string DepartmentName { get; set; }
    public string EmployeeName { get; set; }
    public string EmployeeEmail { get; set; }
    public string CertificationTitle { get; set; }
    public DateOnly CertificationIssueDate { get; set; }
}