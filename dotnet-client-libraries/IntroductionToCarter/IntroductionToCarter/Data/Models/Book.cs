namespace IntroductionToCarter.Data.Models;

public class Book
{
    public required Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string ISBN { get; set; }
    public required int Year { get; set; }
}
