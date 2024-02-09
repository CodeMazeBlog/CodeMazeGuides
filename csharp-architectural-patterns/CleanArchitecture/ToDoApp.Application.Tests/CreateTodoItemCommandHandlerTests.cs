using ToDoApp.Application.Commands.CreateToDo;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.Tests;

public class CreateToDoItemCommandHandlerTests
{
    [Fact]
    public void GivenCreateToDoItemCommandHandler_WhenHandleCalled_ThenCreateNewToDoItem()
    {
        // Arrange                          
        var toDoRepositoryMock = new Mock<IToDoRepository>();
        toDoRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<ToDoItem>()))
            .ReturnsAsync(1);
        var createToDoItemCommandHandler = new CreateToDoItemCommandHandler(toDoRepositoryMock.Object);

        var createToDoItemCommand = new CreateToDoItemCommand
        {
            Description = "Test Description"
        };

        // Act
        var result = createToDoItemCommandHandler.Handle(createToDoItemCommand, CancellationToken.None).Result;

        // Assert
        Assert.Equal(1, result);
    }
}