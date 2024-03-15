using ToDoApp.Domain.Entities;

namespace ToDoApp.Domain.Interfaces;

public interface IToDoRepository
{
    Task<List<ToDoItem>> GetAllAsync();
    Task<int> CreateAsync(ToDoItem item);
}
