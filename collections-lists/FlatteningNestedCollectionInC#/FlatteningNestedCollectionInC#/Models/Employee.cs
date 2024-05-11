using FlatteningNestedCollection.Models;

namespace FlatteningNestedCollection;

public record Employee
{
    public string EmployeeName { get; set; }
    public string EmployeeEmail { get; set; }
    public IEnumerable<Certification> Certifications { get; set; }
}
