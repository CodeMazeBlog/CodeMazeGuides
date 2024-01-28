using MediatR;
namespace ToDoApp.Application.Query.ToDoItem
{
public class ToDoItemQuery
    : IRequest<List<Domain.Entities.ToDoItem>>
{
}
}
