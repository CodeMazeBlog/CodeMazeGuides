namespace FlatteningNestedCollectionInCSharp.Models;

public record Employee
{
    public string Name { get; set; }
    public string Email { get; set; }
    public IEnumerable<Certification> Certifications { get; set; }
}
