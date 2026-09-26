using IdentityUserExtension.Data;
using IdentityUserExtension.Models;
using Microsoft.EntityFrameworkCore;

namespace Tests;

public class ApplicationUserModelTest
{
    private static ApplicationDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlite("DataSource=:memory:")
            .Options;

        return new ApplicationDbContext(options);
    }

    [Test]
    public void GivenTheApplicationDbContext_WhenBuildingTheModel_ThenApplicationUserHasAGuidPrimaryKey()
    {
        using var context = CreateContext();

        var keyProperties = context.Model
            .FindEntityType(typeof(ApplicationUser))!
            .FindPrimaryKey()!
            .Properties;

        Assert.That(keyProperties, Has.Count.EqualTo(1));
        Assert.That(keyProperties[0].ClrType, Is.EqualTo(typeof(Guid)));
    }

    [Test]
    public void GivenTheApplicationDbContext_WhenBuildingTheModel_ThenDisplayNameIsCappedAtOneHundredCharacters()
    {
        using var context = CreateContext();

        var displayName = context.Model
            .FindEntityType(typeof(ApplicationUser))!
            .FindProperty(nameof(ApplicationUser.DisplayName))!;

        Assert.That(displayName.GetMaxLength(), Is.EqualTo(100));
        Assert.That(displayName.IsNullable, Is.False);
    }

    [Test]
    public void GivenTheDefaultSchemaVersion_WhenBuildingTheModel_ThenThereIsNoPasskeyTable()
    {
        using var context = CreateContext();

        var tables = context.Model
            .GetEntityTypes()
            .Select(e => e.GetTableName())
            .ToList();

        Assert.That(tables, Does.Not.Contain("AspNetUserPasskeys"));
        Assert.That(tables, Does.Contain("AspNetUsers"));
    }
}
