using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using TaskManagementSystem.DataLayer.Dtos;
using TaskManagementSystem.DataLayer.Entities;

namespace TaskManagementSystem.DataLayer.Repositories
{
    public interface ITaskRepository
    {
        Task AddAsync(UserTaskDto task);
        Task<List<UserTaskDto>> GetAllTasksAsync(string? userId = null);
        Task<UserTaskDto?> GetTaskAsync(int id, string? userId = null);
        Task SaveChangesAsync();
        void Update(UserTaskDto task);
        Task<bool> RemoveAsync(int id);
    }
}