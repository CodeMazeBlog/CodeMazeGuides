namespace Tests
{
    public class DelegatesUnitTest
    {
        private CodeMazeDelegates _codeMazeDelegates;

        [SetUp]
        public void Setup()
        {
            _codeMazeDelegates = new CodeMazeDelegates();
        }

        [TestCase(10, 25.50f, 10.50)]
        [TestCase(14, 65.50f, 40.50)]
        [TestCase(85, 15.50f, 5.2)]
        public void WhenFetchingTotalSum_ThenCheckForZeroInputValue(int x, float y, double z)
        {
            //Act
            Func<int, float, double, double> funcDelegate = _codeMazeDelegates.ReturnsTheTotalSum;
            var totalSum = funcDelegate.Invoke(x, y, z);

            //Assert
            Assert.AreEqual((x + y + z), totalSum);
        }

        [TestCase(10, 10.50f, 2.50)]
        [TestCase(20, 50.50f, 5.50)]
        public void WhenPrintingTotalSum_ThenCheckForZeroInputValue(int x, float y, double z)
        {
            try
            {
                //Act
                Action<int, float, double> funcDelegate = _codeMazeDelegates.PrintsTheTotalSum;
                funcDelegate.Invoke(x, y, z);

                //Assert
                Assert.Pass();
            }
            catch (ArgumentException ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}