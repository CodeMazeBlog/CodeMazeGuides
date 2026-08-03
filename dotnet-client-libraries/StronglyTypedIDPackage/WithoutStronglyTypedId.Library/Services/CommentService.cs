using WithoutStronglyTypedId.Library.Models;

namespace WithoutStronglyTypedId.Library.Services;

public class CommentService
{
    private static List<Comment> _comments =
    [
        new ()
        {
            Id = Guid.Parse("5c6a8f59-02c1-4f5b-bc85-bfea9ed3a6e4"),
            Text = "First comment made by user.",
            UserId = Guid.Parse("3b3b1a5d-6cd1-42f2-9331-fc6f716e9a2c")
        }
    ];

    public Comment GetSingleUserComment(Guid commentId, Guid userId)
    {
        var comment = _comments
            .FirstOrDefault(comment => comment.Id == commentId // Change `commentId` to `userId` and observe the behaviour.
                            && comment.UserId == userId);

        return comment ?? throw new NullReferenceException();
    }
}
