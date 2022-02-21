using Microsoft.EntityFrameworkCore;
using Minimal_API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("api"));
builder.Services.AddScoped<IArticleService, ArticleService>();

var app = builder.Build();

app.MapGet("/articles", async (IArticleService articleService) 
    => await articleService.GetArticles());

app.MapGet("/articles/{id}", async (int id, IArticleService articleService) 
    => await articleService.GetArticleById(id));

app.MapPost("/articles", async (ArticleRequest articleRequest, IArticleService articleService) 
    => await articleService.CreateArticle(articleRequest));

app.MapPut("/articles/{id}", async (int id, ArticleRequest articleRequest, IArticleService articleService) 
    => await articleService.UpdateArticle(id, articleRequest));

app.MapDelete("/articles/{id}", async (int id, IArticleService articleService) 
    => await articleService.DeleteArticle(id));

app.Run();
