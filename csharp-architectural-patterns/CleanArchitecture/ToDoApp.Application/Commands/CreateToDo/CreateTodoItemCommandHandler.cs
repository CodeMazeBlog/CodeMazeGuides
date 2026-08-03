using MediatR;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interfaces;

namespace ToDoApp.Application.Commands.CreateToDo;

public class CreateToDoItemCommandHandler(IToDoRepository toDoRepository)
    : IRequestHandler<CreateToDoItemCommand, int>
{
    public Task<int> Handle(
        CreateToDoItemCommand request, CancellationToken cancellationToken)
    {
        var item = new ToDoItem
        {
            Description = request.Description
        };

        return toDoRepository.CreateAsync(item);
    }
}
