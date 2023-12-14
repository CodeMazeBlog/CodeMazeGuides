namespace MSTests;

[TestClass]
public class MSTestUserServiceTests
{
    private const string USER_NAME = "Admin";
    private const string PASSWORD = "pass123";
    private const string OTHER_PASSWORD = "Pass124";

    private UserService? userService;

    [TestInitialize]
    public void TestInitialize()
    {
        userService = new UserService();
        userService.AddUser(new User(USER_NAME, PASSWORD));
    }

    [TestCleanup]
    public void TestCleanup()
    {
        userService?.RemoveUser(USER_NAME);
    }

    [TestMethod]
    public void GivenValidCredentials_WhenAuthenticate_ThenShouldReturnTrue()
    {
        var isAuthenticated = userService?.Authenticate(USER_NAME, PASSWORD);

        Assert.IsTrue(isAuthenticated);
    }

    [TestMethod]
    public void GivenInvalidCredentials_WhenAuthenticate_ThenShouldReturnFalse()
    {
        var isAuthenticated = userService?.Authenticate(USER_NAME, OTHER_PASSWORD);

        Assert.IsFalse(isAuthenticated);
    }
}
