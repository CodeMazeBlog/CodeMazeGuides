using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.DataLayer.Dtos;
using TaskManagementSystem.Domain.Constants;
using TaskManagementSystem.Extensions;
using TaskManagementSystem.ViewModels;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;

        public TasksController(ITaskService taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }

        [Authorize(Roles = RoleConstants.Admin_Manager_User)]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(string? userId = null)
        {
            var user = User.GetUser();
            List<UserTaskDto> userTasks;
            if (user.Role == RoleConstants.Admin || user.Role == RoleConstants.Manager)
            {
                userTasks = await _taskService.GetUserTasksAsync(userId);
                return Ok(userTasks);
            }
            userTasks = await _taskService.GetUserTasksAsync(user.UserId);
            return Ok(userTasks);
        }

        [Authorize(Roles = RoleConstants.Admin_Manager_User)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var user = User.GetUser();
            UserTaskDto userTask;
            if (user.Role == RoleConstants.Admin || user.Role == RoleConstants.Manager)
            {
                userTask = await _taskService.GetUserTaskAsync(id);
                return Ok(userTask);
            }
            userTask = await _taskService.GetUserTaskAsync(id, user.UserId);
            return Ok(userTask);
        }

        [Authorize(Roles = RoleConstants.Admin_Manager_User)]
        [HttpPost]
        public async Task<IActionResult> PostAsync(UserTaskViewModel model)
        {
            var user = User.GetUser();
            if(user.Role == RoleConstants.User)
            {
                model.AsssignedToId = user.UserId;
            }
            var userTask = _mapper.Map<UserTaskDto>(model);
            await _taskService.AddAsync(userTask);
            return Ok();
        }

        [Authorize(Roles = RoleConstants.Manager)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, UserTaskViewModel model)
        {
            var userTask = _mapper.Map<UserTaskDto>(model);
            userTask.Id = id;
            await _taskService.UpdateAsync(userTask);
            return Ok();
        }

        [Authorize(Roles = RoleConstants.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _taskService.DeleteAsync(id);
            return Ok();
        }
    }
}
