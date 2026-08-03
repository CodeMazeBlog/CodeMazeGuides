using Firebase.Auth;
using Firebase.Auth.Providers;
using FirebaseAuthentication.Interfaces;
using FirebaseAuthentication.Services;
using FirebaseAdmin;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using System.Net;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizePage("/Auth/AuthenticatedPage");
});

// Firebase app authentication setup
var credentialsFileLocation = builder.Configuration.GetValue<string>("GoogleCredentialsFileLocation");
var firebaseProjectName = builder.Configuration.GetValue<string>("FirebaseProjectName");
var firebaseApiKey = builder.Configuration.GetValue<string>("FirebaseApiKey");

Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialsFileLocation);
builder.Services.AddSingleton(FirebaseApp.Create());

// Authentication setup
builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig
{
    ApiKey = firebaseApiKey,
    AuthDomain = $"{firebaseProjectName}.firebaseapp.com",
    Providers = new FirebaseAuthProvider[]
    {
        new EmailProvider(),
        new GoogleProvider()
    }
}));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = $"https://securetoken.google.com/{firebaseProjectName}";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = $"https://securetoken.google.com/{firebaseProjectName}",
            ValidateAudience = true,
            ValidAudience = firebaseProjectName,
            ValidateLifetime = true
        };
    });

builder.Services.AddSingleton<IFirebaseAuthService, FirebaseAuthService>();

builder.Services.AddSession();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.Use(async (context, next) =>
{
    var token = context.Session.GetString("token");
    if (!string.IsNullOrEmpty(token))
    {
        context.Request.Headers.Add("Authorization", "Bearer " + token);
    }
    await next();
});

app.UseStatusCodePages(async contextAccessor =>
{
    var response = contextAccessor.HttpContext.Response;

    if (response.StatusCode == (int)HttpStatusCode.Unauthorized)
    {
        response.Redirect("/Auth/UnauthenticatedPage");
    }
});

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

public partial class Program { }