using StronglyTypedIds;

namespace WithStronglyTypedId.Library.Models;

[StronglyTypedId(Template.String)]
public partial struct CommentId { }

public class Comment
{
    public CommentId Id { get; set; }
    public string? Text { get; set; }
    public UserId UserId { get; set; }
    public User? User { get; set; }
}
