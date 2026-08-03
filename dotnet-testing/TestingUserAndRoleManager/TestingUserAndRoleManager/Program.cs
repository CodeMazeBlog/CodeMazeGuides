using TestingUserAndRoleManager.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using TestingUserAndRoleManager;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));

builder.Services.AddIdentity<User, IdentityRole>(opt =>
{
    opt.Password.RequiredLength = 7;
    opt.Password.RequireDigit = false;
    opt.Password.RequireUppercase = false;

    opt.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<ApplicationContext>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
