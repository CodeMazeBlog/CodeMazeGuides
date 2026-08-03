namespace FlatteningNestedCollectionInCSharp.Models;

public record DepartmentFlattenedComplex(
    string DepartmentName, 
    string EmployeeName, 
    string EmployeeEmail, 
    string CertificationTitle, 
    DateOnly CertificationIssueDate
);