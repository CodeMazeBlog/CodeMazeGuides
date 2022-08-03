using Microsoft.EntityFrameworkCore;
using TwoFactorAuthentication.Areas.Identity.Services;
using TwoFactorSMSAuthentication.Areas.Identity.Data;
using TwoFactorSMSAuthentication.Data;
namespace TwoFactorSMSAuthentication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DataContextConnection") ?? throw new InvalidOperationException("Connection string 'DataContextConnection' not found.");

            builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(connectionString));

            builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
                            .AddEntityFrameworkStores<DataContext>();

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddTransient<ISmsSender, MessageSender>();
            builder.Services.Configure<SMSOptions>(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication(); ;

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}