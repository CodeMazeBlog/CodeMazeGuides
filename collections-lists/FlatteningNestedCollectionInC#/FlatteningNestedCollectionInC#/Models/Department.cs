namespace FlatteningNestedCollection.Models;

public record Department
{
    public string Name { get; init; }
    public IEnumerable<Employee> Employees { get; init; }
    public IEnumerable<Project> Projects { get; init; }
}
