using MediatR;
using ToDoApp.Domain.Interfaces;

namespace ToDoApp.Application.Queries.ToDoItem;

public class ToDoItemQueryHandler(IToDoRepository toDoRepository)
    : IRequestHandler<ToDoItemQuery, List<Domain.Entities.ToDoItem>>
{
    public Task<List<Domain.Entities.ToDoItem>> Handle(
        ToDoItemQuery request, CancellationToken cancellationToken)
    {
        return toDoRepository.GetAllAsync();
    }
}