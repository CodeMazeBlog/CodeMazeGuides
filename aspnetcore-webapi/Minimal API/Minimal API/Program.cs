using Microsoft.EntityFrameworkCore;
using Minimal_API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("api"));

var app = builder.Build();

app.MapGet("/articles", ArticleService.GetArticles);

app.MapGet("/articles/{id}", ArticleService.GetArticleById);

app.MapPost("/articles", ArticleService.CreateArticle);

app.MapPut("/articles/{id}", ArticleService.UpdateArticle);

app.MapDelete("/articles/{id}", ArticleService.DeleteArticle);

app.Run();
