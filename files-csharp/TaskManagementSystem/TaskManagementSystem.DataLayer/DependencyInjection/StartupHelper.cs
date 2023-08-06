using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.InMemory;
using TaskManagementSystem.DataLayer.DbContexts;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.DataLayer.Interfaces;
using TaskManagementSystem.DataLayer.Repositories;
using Microsoft.AspNetCore.Identity;
using TaskManagementSystem.DataLayer.Entities;
using TaskManagementSystem.DataLayer.Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace TaskManagementSystem.DataLayer.DependencyInjection
{
    public static class StartupHelper
    {
        public static void AddDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            //DbContext
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlite($"Data Source={nameof(ApplicationDbContext)}.db");
            });

            services.AddAutoMapper(config => config.AddProfile<DataMapper>());

            //Identity
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                };
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 6;
            });

            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
        }
    }
}
