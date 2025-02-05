using HybridCachingDotNet.Models;
using HybridCachingDotNet.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Hybrid;

var builder = WebApplication.CreateBuilder(args);

#pragma warning disable EXTEXP0018 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
builder.Services.AddHybridCache(options =>
{
    options.MaximumPayloadBytes = 1024 * 10 * 10;
    options.MaximumKeyLength = 256;

    options.DefaultEntryOptions = new HybridCacheEntryOptions
    {
        Expiration = TimeSpan.FromMinutes(30),
        LocalCacheExpiration = TimeSpan.FromMinutes(30)
    };

    options.ReportTagMetrics = true;
    options.DisableCompression = true;
});
#pragma warning restore EXTEXP0018 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.

builder.Services.AddScoped<ICmCourseService, CmCourseService>();

var app = builder.Build();

app.MapGet("/cm-courses/{id}", async (
    ICmCourseService cmCourseService, 
    int id, 
    CancellationToken cancellationToken) =>
    {
        var result = await cmCourseService.GetCourseAsync(id, cancellationToken);
        return Results.Ok(result);
    }
);

app.MapPost("/cm-courses", async (
    ICmCourseService cmCourseService,
    [FromBody]CmCourse course,
    CancellationToken cancellationToken) =>
{
    await cmCourseService.PostCourseAsync(course, cancellationToken);
    return Results.Ok();
}
);

app.MapDelete("/cm-courses/{id}", async (
    ICmCourseService cmCourseService,
    int id,
    CancellationToken cancellationToken) =>
{
    await cmCourseService.InvalidateByCourseIdAsync(id, cancellationToken);
    return Results.Ok();
}
);

app.MapDelete("/cm-courses/category/{tag}", async (
    ICmCourseService cmCourseService,
    string tag,
    CancellationToken cancellationToken) =>
{
    await cmCourseService.InvalidateByCategoryAsync(tag, cancellationToken);
    return Results.Ok();
}
);

app.Run();

