namespace WithoutStronglyTypedId.Library.Models;

public class Comment
{
    public Guid Id { get; set; }
    public string? Text { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
}
