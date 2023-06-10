using Firebase;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Authentication;
using Firebase.Interfaces;
using Firebase.Services;
using FirebaseAdmin;
using Google.Cloud.Firestore;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizePage("/Firestore/Create");
});

// Firebase app authentication setup
var credentialsFileLocation = builder.Configuration.GetValue<string>("GoogleCredentialsFileLocation");
var firebaseProjectName = builder.Configuration.GetValue<string>("FirebaseProjectName");
var firebaseApiKey = builder.Configuration.GetValue<string>("FirebaseApiKey");

Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialsFileLocation);
builder.Services.AddSingleton(FirebaseApp.Create());


// Firestore setup
builder.Services.AddSingleton<IFirestoreService>(s => new FirestoreService(
    FirestoreDb.Create(firebaseProjectName)
    ));

// Storage setup
builder.Services.AddSingleton<IFirebaseStorageService>(s => new FirebaseStorageService(StorageClient.Create()));

// Authentication setup
builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig
{
    ApiKey = firebaseApiKey,
    AuthDomain = $"{firebaseProjectName}.firebaseapp.com",
    Providers = new FirebaseAuthProvider[]
    {
        new EmailProvider()
    }
}));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddScheme<AuthenticationSchemeOptions, FirebaseAuthenticationHandler>(JwtBearerDefaults.AuthenticationScheme, (o) => { });
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

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

public partial class Program { }