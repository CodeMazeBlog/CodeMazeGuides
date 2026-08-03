namespace FlatteningNestedCollectionInCSharp.Models;

public record Employee(
    string Name, 
    string Email, 
    IEnumerable<Certification>? Certifications = null
);