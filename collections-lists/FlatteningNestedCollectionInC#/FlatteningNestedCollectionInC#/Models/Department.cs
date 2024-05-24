namespace FlatteningNestedCollectionInCSharp.Models;

public record Department
{
    public string Name { get; set; }
    public IEnumerable<Employee> Employees { get; set; }
    public IEnumerable<Project> Projects { get; set; }
}
