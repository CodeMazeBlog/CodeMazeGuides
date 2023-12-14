namespace XUnitTests;

public class XUnitUserServiceTest : IDisposable
{
    private const string USER_NAME = "Admin";
    private const string PASSWORD = "pass123";
    private const string OTHER_PASSWORD = "Pass124";

    private UserService? userService;
    public XUnitUserServiceTest()
    {
        userService = new UserService();
        userService.AddUser(new User(USER_NAME, PASSWORD));
    }

    public void Dispose()
    {
        userService?.RemoveUser(USER_NAME);
    }

    [Fact]
    public void GivenValidCredentials_WhenAuthenticate_ThenShouldReturnTrue()
    {
        var isAuthenticated = userService?.Authenticate(USER_NAME, PASSWORD);

        Assert.True(isAuthenticated);
    }

    [Fact]
    public void GivenInvalidCredentials_WhenAuthenticate_ThenShouldReturnFalse()
    {
        var isAuthenticated = userService?.Authenticate(USER_NAME, OTHER_PASSWORD);

        Assert.False(isAuthenticated);
    }
}
