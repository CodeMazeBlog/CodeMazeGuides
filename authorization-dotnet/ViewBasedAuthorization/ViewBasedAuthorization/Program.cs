using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ViewBasedAuthorization.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DocumentContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<DocumentContext>();

builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/Login");

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("EditDocument", policy => policy.RequireClaim("Permission", "CanEdit"))
    .AddPolicy("DeleteDocument", policy => policy.RequireRole("Admin"));

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetService(typeof(UserManager<IdentityUser>)) as UserManager<IdentityUser>;
    var roleManager = scope.ServiceProvider.GetService(typeof(RoleManager<IdentityRole>)) as RoleManager<IdentityRole>;

    DataInitializer.SeedData(userManager, roleManager);
}

app.MapRazorPages();

app.Run();
  