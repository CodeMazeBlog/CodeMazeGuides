using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.DataLayer.DbContexts;
using TaskManagementSystem.DataLayer.Dtos;
using TaskManagementSystem.DataLayer.Entities;

namespace TaskManagementSystem.DataLayer.Repositories
{
    internal class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TaskRepository(
            ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        public async Task<List<UserTaskDto>> GetAllTasksAsync(string? userId = null)
        {
            var tasks = await _context.Tasks
                .AsNoTracking()
                .Where(x => userId == null || x.AssignedToId == userId)
                .ToListAsync();
            return _mapper.Map<List<UserTaskDto>>(tasks);
        }

        public async Task<UserTaskDto?> GetTaskAsync(int id, string? userId = null)
        {
            var task = await _context.Tasks
                .AsNoTracking()
                .Where(x => userId == null | x.CreatedById == userId)
                .FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<UserTaskDto>(task);
        }

        public async Task AddAsync(UserTaskDto task)
        {
            var userTask = _mapper.Map<UserTask>(task);
            await _context.AddAsync(userTask);
        }

        public void Update(UserTaskDto task)
        {
            var userTask = _mapper.Map<UserTask>(task);
            _context.Update(userTask);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var userTask = await GetTaskAsync(id);
            if (userTask is null) return false;
            _context.Remove(userTask);
            return true;
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
