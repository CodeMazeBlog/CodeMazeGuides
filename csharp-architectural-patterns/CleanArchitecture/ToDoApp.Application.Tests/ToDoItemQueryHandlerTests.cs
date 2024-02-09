using ToDoApp.Application.Queries.ToDoItem;

namespace ToDoApp.Application.Tests;

public class ToDoItemQueryHandlerTests
{
    [Fact]
    public async Task GivenToDoItemQueryHandler_WhenHandleCalled_ThenReturnToDoItems()
    {
        // Arrange
        var mockRepository = new Mock<IToDoRepository>();
        mockRepository.Setup(x => x.GetAllAsync())
            .ReturnsAsync(
            [
                new() { Description = "Item 1" },
                new() { Description = "Item 2" }
            ]);

        var handler = new ToDoItemQueryHandler(mockRepository.Object);
        var query = new ToDoItemQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal("Item 1", result[0].Description);
        Assert.Equal("Item 2", result[^1].Description);
    }
}
