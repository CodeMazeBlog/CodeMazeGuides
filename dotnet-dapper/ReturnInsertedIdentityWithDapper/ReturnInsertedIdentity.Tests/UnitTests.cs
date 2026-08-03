using static ReturnInsertedIdentityWithDapper.Methods;

namespace ReturnInsertedIdentity.Tests;

public class UnitTests
{
    private string _connectionString;

    [SetUp]
    public void Setup()
    {
        _connectionString = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build()
            .GetConnectionString("DefaultConnection")!;
    }

    [Test]
    public void GivenOutputInsertedMethod_WhenNewRecord_ThenReturnedIDGreaterThanZeroLiveTest()
    {
        var newStudent = new Student { Firstname = "Mary", Surname = "Williams" };

        var lastInsertedId = UseOfOutputInserted(_connectionString, newStudent);

        Assert.That(lastInsertedId, Is.GreaterThan(0));
    }

    [Test]
    public void GivenScopeIdentityMethod_WhenNewRecord_ThenReturnedIDGreaterThanZeroLiveTest()
    {
        var newStudent = new Student { Firstname = "Bob", Surname = "Brown" };

        var lastInsertedId = UseOfScopeIdentity(_connectionString, newStudent);

        Assert.That(lastInsertedId, Is.GreaterThan(0));
    }
}