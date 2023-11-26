using DifferencesBetweenNUnitXUnitandMStest;

namespace MSTests
{
    [TestClass]
    public class MSTestUserServiceTests
    {
        private UserService? userService;

        [TestInitialize]
        public void TestInitialize()
        {
            userService = new UserService();
            userService.AddUser(new User("Admin", "pass123"));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            userService?.RemoveUser("Admin");
            userService = null;
        }

        [TestMethod]
        public void GivenValidCredentials_WhenAuthenticate_ThenSouldReturnTrue()
        {
            var username = "Admin";
            var password = "pass123";

            var isAuthenticated = userService?.Authenticate(username, password);

            Assert.IsTrue(isAuthenticated);
        }

        [TestMethod]
        public void GivenInvalidCredentials_WhenAuthenticate_ThenSouldReturnFalse()
        {
            var username = "Admin";
            var password = "Pass124";

            var isAuthenticated = userService?.Authenticate(username, password);

            Assert.IsFalse(isAuthenticated);
        }
    }
}
