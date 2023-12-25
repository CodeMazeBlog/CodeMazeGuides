using Asp.Versioning;
using VersioningRestAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var apiVersioningBuilder = builder.Services.AddApiVersioning(o =>
{
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new ApiVersion(2, 0);
    o.ReportApiVersions = true;
    o.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Version"),
        new MediaTypeApiVersionReader("ver"));
});

apiVersioningBuilder.AddApiExplorer(
    options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var apiVersionSet = app.NewApiVersionSet()
    .HasDeprecatedApiVersion(new ApiVersion(1, 0))
    .HasApiVersion(new ApiVersion(2, 0))
    .HasApiVersion(new ApiVersion(3, 0))
    .ReportApiVersions()
    .Build();

app.MapGet("api/minimal/StringList", () =>
{
    var strings = Data.Summaries.Where(x => x.StartsWith("B"));

    return TypedResults.Ok(strings);
})
    .WithApiVersionSet(apiVersionSet)
    .MapToApiVersion(new ApiVersion(1, 0));

app.MapGet("api/minimal/StringList", () =>
{
    var strings = Data.Summaries.Where(x => x.StartsWith("S"));

    return TypedResults.Ok(strings);
})
    .WithApiVersionSet(apiVersionSet)
    .MapToApiVersion(new ApiVersion(2, 0));

app.MapGet("api/minimal/v{version:apiVersion}/StringList", () =>
{
    var strings = Data.Summaries.Where(x => x.StartsWith("C"));

    return TypedResults.Ok(strings);
})
    .WithApiVersionSet(apiVersionSet)
    .MapToApiVersion(new ApiVersion(3, 0));

app.Run();

public partial class Program { }