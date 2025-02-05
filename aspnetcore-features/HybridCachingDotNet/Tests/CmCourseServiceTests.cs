namespace Tests;

using HybridCachingDotNet.Models;
using HybridCachingDotNet.Services;
using Microsoft.Extensions.Caching.Hybrid;
using NSubstitute;

[TestClass]
public class CmCourseServiceTests
{
    [TestMethod]
    public async Task GivenHybridCache_WhenGetCourseAsync_GetOrCreateAsyncIsCalled()
    {
        var hybridCache = Substitute.For<HybridCache>();
        
        var sut = new CmCourseService(hybridCache);

        var actual = await sut.GetCourseAsync(1);

        await hybridCache.Received().GetOrCreateAsync("course-1", 
            Arg.Any<Func<CancellationToken, ValueTask<CmCourse>>>(), 
            Arg.Any<HybridCacheEntryOptions>(),
            Arg.Any<ICollection<string>>(),
            Arg.Any<CancellationToken>()
            );
    }

    [TestMethod]
    public async Task GivenHybridCache_WhenPostCourseAsync_SetAsyncIsCalled()
    {
        var hybridCache = Substitute.For<HybridCache>();

        var sut = new CmCourseService(hybridCache);

        var course = new CmCourse
        {
            Id = 4,
            Name = "NewCourse",
            Category = "NewCategory",
        };

        await sut.PostCourseAsync(course);

        await hybridCache.Received().SetAsync("course-4",
            Arg.Any<CmCourse>(),
            Arg.Any<HybridCacheEntryOptions>(),
            Arg.Any<ICollection<string>>(),
            Arg.Any<CancellationToken>()
            );
    }

    [TestMethod]
    public async Task GivenHybridCache_WhenInvalidateCourseByIdAsync_RemoveAsyncIsCalled()
    {
        var hybridCache = Substitute.For<HybridCache>();

        var sut = new CmCourseService(hybridCache);


        await sut.InvalidateByCourseIdAsync(1);

        await hybridCache.RemoveAsync("course-1",
            Arg.Any<CancellationToken>()
            );
    }

    [TestMethod]
    public async Task GivenHybridCache_WhenInvalidateByCategoryAsync_RemoveByTagAsyncIsCalled()
    {
        var hybridCache = Substitute.For<HybridCache>();

        var sut = new CmCourseService(hybridCache);

        await sut.InvalidateByCategoryAsync("NewCategory");

        await hybridCache.RemoveByTagAsync("cat-NewCategory",
            Arg.Any<CancellationToken>()
            );
    }
}