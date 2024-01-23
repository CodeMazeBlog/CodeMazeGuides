namespace Tests
{
    [TestClass]
    public class NextDoubleGeneratorTest
    {
        [TestMethod]
        [DataRow(0.1, false)]
        [DataRow(0.2, false)]
        [DataRow(0.49, false)]
        [DataRow(0.5, false)]
        [DataRow(0.51, true)]
        [DataRow(0.6, true)]
        [DataRow(0.7, true)]
        [DataRow(0.8, true)]
        public void GivenNumber_WhenGeneratingBoolean_ThenExpectTrueIfNumberIsGreaterThen0_5(double constantNumber, bool epectedResult)
        {
            var generator = Substitute.For<IRandomGenerator>();
            _ = generator.NextDouble().Returns(constantNumber);

            var nextDoubleGenerator = new NextDoubleGenerator(generator);

            var result = nextDoubleGenerator.NextBool();
            Assert.AreEqual(epectedResult, result);
        }
    }
}
