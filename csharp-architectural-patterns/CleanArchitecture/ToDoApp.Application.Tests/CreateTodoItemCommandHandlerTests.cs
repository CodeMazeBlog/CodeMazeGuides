using Moq;
using ToDoApp.Application.Commands.CreateToDo;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interfaces;

namespace ToDoApp.Application.Tests
{
    public class CreateTodoItemCommandHandlerTests
    {
        [Fact]
        public void GivenCreateTodoItemCommandHandler_WhenHandleCalled_ThenCreateNewToDoItem()
        {
            // Arrange                          
            var toDoRepositoryMock = new Mock<IToDoRepository>();
            toDoRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<ToDoItem>()))
                .ReturnsAsync(1);
            var createTodoItemCommandHandler = new CreateTodoItemCommandHandler(toDoRepositoryMock.Object);

            var createTodoItemCommand = new CreateToDoItemCommand
            {
                Description = "Test Description"
            };

            // Act
            var result = createTodoItemCommandHandler.Handle(createTodoItemCommand, CancellationToken.None).Result;

            // Assert
            Assert.Equal(1, result);
        }
    }
}