using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interfaces;

namespace ToDoApp.Persistence;

public class InMemoryToDoRepository : IToDoRepository
{
    private static readonly List<ToDoItem> _items = [];

    public Task<int> CreateAsync(ToDoItem item)
    {
        _items.Add(item);

        return Task.FromResult(item.Id);
    }

    public Task<List<ToDoItem>> GetAllAsync()
    {
        return Task.FromResult(_items);
    }
}