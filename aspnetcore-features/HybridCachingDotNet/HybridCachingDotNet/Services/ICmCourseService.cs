namespace HybridCachingDotNet.Services;

using HybridCachingDotNet.Models;

public interface ICmCourseService
{
    Task<CmCourse?> GetCourseAsync(int id, CancellationToken cancellationToken = default);

    Task PostCourseAsync(CmCourse course, CancellationToken cancellationToken = default);

    Task InvalidateByCourseIdAsync(int id, CancellationToken cancellationToken = default);

    Task InvalidateByCategoryAsync(string tag, CancellationToken cancellationToken = default);
}
