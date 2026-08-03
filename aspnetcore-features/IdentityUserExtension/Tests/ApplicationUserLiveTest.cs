using IdentityUserExtension.Data;
using IdentityUserExtension.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Tests;

public class ApplicationUserLiveTest
{
    [Test]
    public async Task GivenAnApplicationUserWithCustomPrimitiveProperties_WhenLoadingFromDatabase_ThenCanRetrieve()
    {
        var serviceProvider = TestServiceCollectionBuilder.CreateTestServiceProvider();
        var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var user = new ApplicationUser
        {
            UserName = "user1",
            Email = "email@example.com",
            DisplayName = "User 1"
        };
        await using var transaction = await dbContext.Database.BeginTransactionAsync();
        
        try
        {
            var result = await userManager.CreateAsync(user);
            Assert.That(result.Succeeded, Is.True);
            
            var userFromDb = await userManager.FindByNameAsync(user.UserName);
            
            Assert.That(userFromDb, Is.Not.Null);
            Assert.That(userFromDb!.DisplayName, Is.EqualTo(user.DisplayName));
        }
        finally
        {
            await transaction.RollbackAsync();
        }
    }
    
    [Test]
    public async Task GivenAnApplicationUserWithCustomNavigationProperties_WhenLoadingFromDatabase_ThenCanRetrieve()
    {
        var serviceProvider = TestServiceCollectionBuilder.CreateTestServiceProvider();
        var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var user = new ApplicationUser
        {
            UserName = "user1",
            Email = "email@example.com",
            DisplayName = "User 1",
            Posts = new()
            {
                new(){Title = "title1", Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."},
                new(){Title = "title2", Text = "Etiam sed erat ipsum. Donec hendrerit sem accumsan justo efficitur, vel ullamcorper libero tincidunt."}
            }
        };
        await using var transaction = await dbContext.Database.BeginTransactionAsync();
        
        try
        {
            var result = await userManager.CreateAsync(user);
            Assert.That(result.Succeeded, Is.True);
            
            var userFromDb = await userManager.FindByNameAsync(user.UserName);
            
            Assert.That(userFromDb, Is.Not.Null);
            Assert.That(userFromDb!.Posts, Has.Count.EqualTo(user.Posts.Count));
            Assert.That(userFromDb.Posts.Select(x => x.Title), Is.EquivalentTo(user.Posts.Select(x => x.Title)));
            Assert.That(userFromDb.Posts.Select(x => x.Text), Is.EquivalentTo(user.Posts.Select(x => x.Text)));
        }
        finally
        {
            await transaction.RollbackAsync();
        }
    }
}