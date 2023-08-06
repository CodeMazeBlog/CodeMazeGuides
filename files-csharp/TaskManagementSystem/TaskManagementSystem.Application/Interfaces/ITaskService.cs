using TaskManagementSystem.DataLayer.Dtos;

namespace TaskManagementSystem.Application.Interfaces
{
    public interface ITaskService
    {
        Task AddAsync(UserTaskDto userTaskDto);
        Task<UserTaskDto> GetUserTaskAsync(int id, string? userId = null);
        Task<List<UserTaskDto>> GetUserTasksAsync(string? userId = null);
        Task UpdateAsync(UserTaskDto userTaskDto);
        Task DeleteAsync(int id);
    }
}