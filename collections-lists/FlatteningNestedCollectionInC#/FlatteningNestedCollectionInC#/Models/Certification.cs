namespace FlatteningNestedCollection.Models;

public record Certification
{
    public string Title { get; set; }
    public DateOnly IssueDate { get; set; }
}
