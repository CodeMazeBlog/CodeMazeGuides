using Microsoft.EntityFrameworkCore;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interfaces;

namespace ToDoApp.Persistence;

public class SqlToDoRepository : IToDoRepository
{
    private readonly ToDoDbContext _context;

    public SqlToDoRepository(ToDoDbContext context)
    {
        _context = context;
    }

    public Task<int> CreateAsync(ToDoItem item)
    {
        _context.ToDoItems.Add(item);

        return _context.SaveChangesAsync();
    }

    public Task<List<ToDoItem>> GetAllAsync()
    {
        return _context.ToDoItems.ToListAsync();
    }
}
