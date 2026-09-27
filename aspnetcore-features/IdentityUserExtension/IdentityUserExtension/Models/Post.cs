namespace IdentityUserExtension.Models;

public class Post
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Text { get; set; }
}