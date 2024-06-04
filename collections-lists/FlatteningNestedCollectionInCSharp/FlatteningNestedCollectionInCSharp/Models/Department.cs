namespace FlatteningNestedCollectionInCSharp.Models;

public record Department(
    string Name, IEnumerable<Employee> Employees, 
    IEnumerable<Project>? Projects = null
);