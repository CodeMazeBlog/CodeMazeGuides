using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.DataLayer.Dtos;
using TaskManagementSystem.DataLayer.Repositories;
using TaskManagementSystem.Exceptions.Exceptions;

namespace TaskManagementSystem.Application.Services
{
    internal class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<UserTaskDto>> GetUserTasksAsync(string? userId = null)
        {
            return await _taskRepository.GetAllTasksAsync(userId);
        }

        public async Task<UserTaskDto> GetUserTaskAsync(int id, string? userId = null)
        {
            return await _taskRepository.GetTaskAsync(id, userId) ??
                throw new TaskNotFoundException(id);
        }

        public async Task AddAsync(UserTaskDto userTaskDto)
        {
            await _taskRepository.AddAsync(userTaskDto);
            await _taskRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserTaskDto userTaskDto)
        {
            userTaskDto.DateModified = DateTime.UtcNow;
            _taskRepository.Update(userTaskDto);
            await _taskRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var isSucceeded = await _taskRepository.RemoveAsync(id);
            if(!isSucceeded)
                throw new TaskNotFoundException(id);
            await _taskRepository.SaveChangesAsync();
        }
    }
}
