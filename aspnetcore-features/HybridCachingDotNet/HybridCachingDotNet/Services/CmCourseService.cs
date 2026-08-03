namespace HybridCachingDotNet.Services;

using HybridCachingDotNet.Models;
using Microsoft.Extensions.Caching.Hybrid;

public class CmCourseService(HybridCache cache) : ICmCourseService
{
    public static readonly List<CmCourse> courseList = [
        new CmCourse
        { 
            Id = 1,
            Name = "WebAPI",
            Category = "Backend"
        },
        new CmCourse
        {
            Id = 2,
            Name = "Microservices",
            Category = "Backend"
        },
        new CmCourse
        {
            Id = 3,
            Name = "Blazer",
            Category = "Frontend"
        },
        ];

    public async Task<CmCourse?> GetCourseAsync(int id, CancellationToken cancellationToken = default)
    {
        return await cache.GetOrCreateAsync(
            $"course-{id}",
            async token =>
            {
                await Task.Delay(1000, token);
                var course = courseList.FirstOrDefault(course => course.Id == id);
                return course;
            },
            options: new HybridCacheEntryOptions
            {
                Expiration = TimeSpan.FromMinutes(30),
                LocalCacheExpiration = TimeSpan.FromMinutes(30)
            },
            tags: ["course"],
            cancellationToken: cancellationToken
        );
    }

    public async Task PostCourseAsync(CmCourse course, CancellationToken cancellationToken = default)
    {
        courseList.Add(course);

        await cache.SetAsync($"course-{course.Id}",
            course,
            options: new HybridCacheEntryOptions
            {
                Expiration = TimeSpan.FromMinutes(30),
                LocalCacheExpiration = TimeSpan.FromMinutes(30)
            },
            tags: [$"cat-{course.Category}"],
            cancellationToken: cancellationToken);
    }

    public async Task InvalidateByCourseIdAsync(int id, CancellationToken cancellationToken = default)
    {
        await cache.RemoveAsync($"course-{id}", cancellationToken);
    }

    public async Task InvalidateByCategoryAsync(string tag, CancellationToken cancellationToken = default)
    {
        await cache.RemoveByTagAsync($"cat-{tag}", cancellationToken);
    }
}
