using WithStronglyTypedId.Library.Models;

namespace WithStronglyTypedId.Library.Services;

public class StronglyTypedIdCommentService
{
    private static List<Comment> _comments =
    [
        new ()
        {
            Id = new CommentId(),
            Text = "First comment made by user.",
            UserId = new UserId()
        }
    ];

    public Comment GetSingleUserComment(CommentId commentId, UserId userId)
    {
        var comment = _comments
            .FirstOrDefault(comment => comment.Id == commentId // Change `commentId` to `userId` and observe the behaviour.
                            && comment.UserId == userId);

        return comment ?? throw new NullReferenceException();
    }
}
