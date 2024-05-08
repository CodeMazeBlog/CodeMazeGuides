namespace Tests;

public class StronglyTypedIdUnitTests
{
    private readonly StronglyTypedIdCommentService _stronglyTypedIdCommentService;
    private readonly CommentService _commentService;

    public StronglyTypedIdUnitTests()
    {
        _stronglyTypedIdCommentService = new StronglyTypedIdCommentService();
        _commentService = new CommentService();
    }

    [Fact]
    public void GivenValidCommentIdAndUserId_ThenReturnCommentForStronglyTypedId()
    {
        // Arrange
        var validCommentId = new CommentId();
        var validUserId = new UserId();

        // Act
        var comment = _stronglyTypedIdCommentService
            .GetSingleUserComment(validCommentId, validUserId);

        // Assert
        Assert.NotNull(comment);
    }

    [Fact]
    public void GivenValidCommentIdAndUserId_ThenReturnCommentForPrimitiveType()
    {
        // Arrange
        var validCommentId = Guid.Parse("5c6a8f59-02c1-4f5b-bc85-bfea9ed3a6e4");
        var validUserId = Guid.Parse("3b3b1a5d-6cd1-42f2-9331-fc6f716e9a2c");

        // Act
        var result = _commentService
            .GetSingleUserComment(validCommentId, validUserId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("First comment made by user.", result.Text);
    }

    [Fact]
    public void GivenInvalidCommentIdAndValidUserId_ThenThrowNullReferenceException()
    {
        // Arrange
        var invalidCommentId = Guid.Parse("b6e1d9a5-2d5c-49d3-856c-5dc8f4e27648");
        var validUserId = Guid.Parse("3b3b1a5d-6cd1-42f2-9331-fc6f716e9a2c");

        // Act & Assert
        Assert.Throws<NullReferenceException>(()
            => _commentService.GetSingleUserComment(invalidCommentId, validUserId));
    }
}
