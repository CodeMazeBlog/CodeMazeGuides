using IDisposableObjects;
namespace TestIDisposableObjects
{
    [TestClass]
    public class UnitTest
    {
        readonly FileManager fileManager = new();
        [TestMethod]
        public void WhenIDisposablesNotManaged_ThenReturnsCorrectLength()
        {
            int expectedResults = 21;
            int actualResults = fileManager.UnmanagedObjectFileManager();

            Assert.AreEqual(expectedResults, actualResults);
        }

        [TestMethod]
        public void WhenUsingusingStatement_ThenMethodReturnsCorrectLength()
        {
            int expectedResults = 21;
            int actualResults = fileManager.UsingFileManager();

            Assert.AreEqual(expectedResults, actualResults);
        }

        [TestMethod]
        public void WhenUsingTryFinally_ThenMethodReturnsCorrectLength()
        {
            int expectedResults = 21;
            int actualResults = fileManager.TryFinallyFileManager();

            Assert.AreEqual(expectedResults, actualResults);
        }
    }
}