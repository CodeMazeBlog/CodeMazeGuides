namespace FlatteningNestedCollectionInCSharp.Models;

public record DepartmentFlattenedMultipleCollections(
    string DepartmentName, 
    string EmployeeName, 
    string EmployeeEmail, 
    string ProjectTitle, 
    int ProjectBudget
);