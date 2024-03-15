namespace NUnitTests;

[TestFixture]
public class NUnitUserServiceTests
{
    private const string USER_NAME = "Admin";
    private const string PASSWORD = "pass123";
    private const string OTHER_PASSWORD = "Pass124";

    private UserService? userService;

    [SetUp]
    public void Setup()
    {
        userService = new UserService();
        userService.AddUser(new User(USER_NAME, PASSWORD));
    }

    [TearDown]
    public void TearDown()
    {
        userService?.RemoveUser(USER_NAME);
    }

    [Test]
    public void GivenValidCredentials_WhenAuthenticate_ThenShouldReturnTrue()
    {
        var isAuthenticated = userService?.Authenticate(USER_NAME, PASSWORD);

        Assert.That(isAuthenticated, Is.True);
    }

    [Test]
    public void GivenInvalidCredentials_WhenAuthenticate_ThenShouldReturnFalse()
    {
        var isAuthenticated = userService?.Authenticate(USER_NAME, OTHER_PASSWORD);

        Assert.That(isAuthenticated, Is.False);
    }
}
