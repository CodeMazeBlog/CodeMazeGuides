using HexagonalArchitecturalPatternInCSharp.Core.Entities;

namespace HexagonalArchitecturalPatternInCSharp.Core.Ports.Driving;

public interface IWritingService
{
    Task ChangeArticleStatusAsync(Guid articleId, WritingStatus writingStatus);

    Task StartWritingAsync(Guid authorId, Guid articleId);
}
