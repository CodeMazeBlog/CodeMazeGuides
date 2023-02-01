using ActionAndFunctionDelegates.Controllers;
using Newtonsoft.Json.Linq;

namespace Tests
{
    [TestClass]
    public class DelegatesUnitTest
    { 
        [TestMethod]
        public void GivenTwoFactors_AndTheRightProduct_ThenAreEqual()
        {
            var controller = new DelegatesController();

            Assert.AreEqual(36, controller.GetProduct(6,6));
        }
        [TestMethod]
        public void GivenTwoFactors_AndTheSum_ThenNotEqual()
        {
            var controller = new DelegatesController();

            Assert.AreNotEqual(12, controller.GetProduct(6, 6));
        }
        [TestMethod]
        public void GivenADirectoryName_AndRightName_ThenDirectoryExists()
        {
            var controller = new DelegatesController();
            string currentPath = Directory.GetCurrentDirectory();
            string s = "hello";
            controller.CreateDirectory(s);

            Assert.IsTrue(Directory.Exists(Path.Combine(currentPath, s)));
        }
        [TestMethod]
        public void GivenADirectoryName_AndWrongName_ThenDirectoryDoesNotExist()
        {
            var controller = new DelegatesController();
            string currentPath = Directory.GetCurrentDirectory();
            string s = "hello";
            controller.CreateDirectory(s);

            Assert.IsFalse(Directory.Exists(Path.Combine(currentPath, "fifteen")));
        }
    }
}