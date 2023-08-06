using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Exceptions.Middlewares;

namespace TaskManagementSystem.Exceptions.Extensions
{
    public static class StartupExtensions
    {
        public static void UserExceptionMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
