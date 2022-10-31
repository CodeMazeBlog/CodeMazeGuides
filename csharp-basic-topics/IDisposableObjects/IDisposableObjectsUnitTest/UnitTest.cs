using IdisposableObjects;
namespace TestIDisposableObjects

{
    [TestClass]
    public class UnitTest
    {

        [TestMethod]
        public void WhenIDisposablesNotDisposed_MethodRunsSuccessfully()
        {
            // arrange
            int expectedResults = 21;
            //act
            int actualResults = Program.UnmanagedObjectFileManager();
            //assert
            Assert.AreEqual(expectedResults, actualResults);
        }

        [TestMethod]
        public void WhenUsingusingStatement_MethodReturnsCorrectLength()
        {
            // arrange
            int expectedResults = 21;
            //act
            int actualResults = Program.UsingusingFileManager();
            //assert
            Assert.AreEqual(expectedResults, actualResults);
        }
        [TestMethod]
        public void WhenUsingTryFinally_MethodReturnsCorrectLength()
        {
            // arrange
            int expectedResults = 21;
            //act
            int actualResults = Program.UsingTryFinallyFileManager();
            //assert
            Assert.AreEqual(expectedResults, actualResults);
        }
    }
}