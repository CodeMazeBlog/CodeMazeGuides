using HexagonalArchitecturalPatternInCSharp.Core.Ports.Driven;
using HexagonalArchitecturalPatternInCSharp.Core.Ports.Driving;
using HexagonalArchitecturalPatternInCSharp.Core.Services;
using HexagonalArchitecturalPatternInCSharp.Messaging.Publishers;
using HexagonalArchitecturalPatternInCSharp.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace HexagonalArchitecturalPatternInCSharp;

public static class ServiceExtensions
{
    public static void AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<WritingDbContext>(opt => opt.UseInMemoryDatabase("WritingDb"));
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IArticleRepository, ArticleRepository>();
    }

    public static void AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IArticleService, ArticleService>();
        services.AddScoped<IWritingService, WritingService>();
    }

    public static void AddMessaging(this IServiceCollection services)
    {
        services.AddScoped<IMessagePublisher, MessagePublisher>();
    }
}