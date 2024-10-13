using Carter;
using Carter.Response;

public class BlogModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/blogs", (HttpResponse response) => response.Negotiate(GetBlogs()));
    }

    private static Blog[] GetBlogs()
    {
        var blogs = new Blog[]
        {
            new()
            {
                Id = 1,
                DatePublished = DateOnly.FromDateTime(DateTime.Now),
                Title = "Building .NET Minimal API's",
                Tags = ["c#", ".net", "api"]
            },
            new()
            {
                Id = 2,
                DatePublished = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)),
                Title = "Content Negotiation in .NET API's",
                Tags = [ "c#", ".net", "api", "content negotiation"]
            },
            new()
            {
                Id = 3,
                DatePublished = DateOnly.FromDateTime(DateTime.Now.AddDays(-2)),
                Title = "Using .http files to test APIs",
                Tags = ["c#", ".net", "api", "testing"]
            },
            new()
            {
                Id = 4,
                DatePublished = DateOnly.FromDateTime(DateTime.Now.AddDays(-3)),
                Title = "Different Web Content Types",
                Tags = ["web", "content types"]
            }
        };

        return blogs;
    }
}
