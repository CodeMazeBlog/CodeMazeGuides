namespace PassComplexParametersToTheory.Data;

public class Book
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required int AuthorId { get; set; }
    public bool IsCheckedOut { get; set; } = false;
}
