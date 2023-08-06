using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.Application.Services;

namespace TaskManagementSystem.Application.DependencyInjection
{
    public static class StartupHelper
    {
        public static void AddApplicationLayer(this IServiceCollection services) 
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITaskService, TaskService>();
        }
    }
}
