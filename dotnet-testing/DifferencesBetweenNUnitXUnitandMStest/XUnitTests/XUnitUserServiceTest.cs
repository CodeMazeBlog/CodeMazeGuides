using DifferencesBetweenNUnitXUnitandMStest;

namespace XUnitTests
{
    public class XUnitUserServiceTest : IDisposable
    {
        private UserService? userService;
        public XUnitUserServiceTest()
        {
            userService = new UserService();
            userService.AddUser(new User("Admin", "pass123"));
        }

        public void Dispose()
        {
            userService?.RemoveUser("Admin");
            userService = null;
        }

        [Fact]
        public void GivenValidCredentials_WhenAuthenticate_ThenSouldReturnTrue()
        {
            var username = "Admin";
            var password = "pass123";

            var isAuthenticated = userService?.Authenticate(username, password);

            Assert.True(isAuthenticated);
        }

        [Fact]
        public void GivenInvalidCredentials_WhenAuthenticate_ThenSouldReturnFalse()
        {
            var username = "Admin";
            var password = "Pass124";

            var isAuthenticated = userService?.Authenticate(username, password);

            Assert.False(isAuthenticated);
        }
    }
}
