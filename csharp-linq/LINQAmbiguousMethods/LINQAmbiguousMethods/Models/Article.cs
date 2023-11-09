namespace LINQAmbiguousMethods.Models;

public class Article
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
}
