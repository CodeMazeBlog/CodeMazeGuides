using DifferencesBetweenNUnitXUnitandMStest;

namespace NUnitTests;

[TestFixture]
public class NUnitUserServiceTests
{
    private UserService? userService;

    [SetUp]
    public void Setup()
    {
        userService = new UserService();
        userService.AddUser(new User("Admin", "pass123"));
    }

    [TearDown]
    public void TearDown()
    {
        userService?.RemoveUser("Admin");
        userService = null;
    }

    [Test]
    public void GivenValidCredentials_WhenAuthenticate_ThenSouldReturnTrue()
    {
        var username = "Admin";
        var password = "pass123";

        var isAuthenticated = userService?.Authenticate(username, password);

        Assert.That(isAuthenticated, Is.True);
    }

    [Test]
    public void GivenInvalidCredentials_WhenAuthenticate_ThenSouldReturnFalse()
    {
        var username = "Admin";
        var password = "Pass124";

        var isAuthenticated = userService?.Authenticate(username, password);

        Assert.That(isAuthenticated, Is.False);
    }
}
