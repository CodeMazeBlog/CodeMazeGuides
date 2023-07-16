using IdentityUserExtension.Data;
using IdentityUserExtension.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Tests;

public class ApplicationUserIntegrationTest
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
            AdditionalEmailAddresses = new()
            {
                new(){UsedForLogin = true, Value = "email2@example.com"},
                new(){UsedForLogin = true, Value = "email3@example.com"}
            }
        };
        await using var transaction = await dbContext.Database.BeginTransactionAsync();
        
        try
        {
            var result = await userManager.CreateAsync(user);
            Assert.That(result.Succeeded, Is.True);
            
            var userFromDb = await userManager.FindByNameAsync(user.UserName);
            
            Assert.That(userFromDb, Is.Not.Null);
            Assert.That(userFromDb!.AdditionalEmailAddresses, Has.Count.EqualTo(user.AdditionalEmailAddresses.Count));
            Assert.That(userFromDb.AdditionalEmailAddresses.Select(x => x.Value), Is.EquivalentTo(user.AdditionalEmailAddresses.Select(x => x.Value)));
        }
        finally
        {
            await transaction.RollbackAsync();
        }
    }
}