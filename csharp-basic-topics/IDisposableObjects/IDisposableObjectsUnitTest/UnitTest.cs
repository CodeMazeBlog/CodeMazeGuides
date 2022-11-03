using IdisposableObjects;
namespace TestIDisposableObjects
{
    [TestClass]
    public class UnitTest
    {
        readonly Program newProgramInstance = new();
        [TestMethod]
        public void WhenIDisposablesNotManaged_ThenMethodRunsSuccessfully()
        {
            int expectedResults = 21;
            int actualResults = newProgramInstance.UnmanagedObjectFileManager();

            Assert.AreEqual(expectedResults, actualResults);
        }

        [TestMethod]
        public void WhenUsingusingStatement_ThenMethodReturnsCorrectLength()
        {
            int expectedResults = 21;
            int actualResults = newProgramInstance.UsingusingFileManager();

            Assert.AreEqual(expectedResults, actualResults);
        }

        [TestMethod]
        public void WhenUsingTryFinally_ThenMethodReturnsCorrectLength()
        {
            int expectedResults = 21;
            int actualResults = newProgramInstance.UsingTryFinallyFileManager();

            Assert.AreEqual(expectedResults, actualResults);
        }
    }
}