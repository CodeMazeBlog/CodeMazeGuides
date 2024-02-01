using MediatR;
namespace ToDoApp.Application.Queries.ToDoItem;

public class ToDoItemQuery
    : IRequest<List<Domain.Entities.ToDoItem>>
{
}
