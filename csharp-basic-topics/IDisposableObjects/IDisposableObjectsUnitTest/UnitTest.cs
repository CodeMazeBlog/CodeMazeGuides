using IdisposableObjects;
namespace TestIDisposableObjects
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void WhenIDisposablesNotManaged_ThenMethodRunsSuccessfully()
        {
            int expectedResults = 21;
            int actualResults = Program.UnmanagedObjectFileManager();

            Assert.AreEqual(expectedResults, actualResults);
        }

        [TestMethod]
        public void WhenUsingusingStatement_ThenMethodReturnsCorrectLength()
        {
            int expectedResults = 21;
            int actualResults = Program.UsingusingFileManager();

            Assert.AreEqual(expectedResults, actualResults);
        }

        [TestMethod]
        public void WhenUsingTryFinally_ThenMethodReturnsCorrectLength()
        {
            int expectedResults = 21;
            int actualResults = Program.UsingTryFinallyFileManager();

            Assert.AreEqual(expectedResults, actualResults);
        }
    }
}