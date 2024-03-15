using AuthorizationPolicyProviders.Authorization.Handlers;
using AuthorizationPolicyProviders.Authorization.PolicyProviders;
using AuthorizationPolicyProviders.Data.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

builder.Services.AddTransient<ILoyaltyRequirementsRepository, SampleLoyaltyRequirementsRepository>();

builder.Services.AddSingleton<IAuthorizationPolicyProvider, LoyaltyProgramAuthorizationPolicyProvider>();

builder.Services.AddSingleton<IAuthorizationHandler, MinimumLoyaltyPointsRequirementHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, BaselineMembershipTierRequirementHandler>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
