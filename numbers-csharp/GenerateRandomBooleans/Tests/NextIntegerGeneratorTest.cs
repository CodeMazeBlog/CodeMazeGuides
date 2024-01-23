namespace Tests
{
    [TestClass]
    public class NextIntegerGeneratorTest
    {
        [TestMethod]
        [DataRow(0, true)]
        [DataRow(1, false)]
        [DataRow(2, false)]
        [DataRow(3, false)]
        [DataRow(4000, false)]
        [DataRow(5013, false)]
        public void GivenNumber_WhenGeneratingBoolean_ThenExpectTrueIfNumberIsZerro(int constantNumber, bool epectedResult)
        {
            var generator = Substitute.For<IRandomGenerator>();
            _ = generator.NextInteger(Arg.Any<int>(), Arg.Any<int>()).Returns(constantNumber);

            var nextIntegerGenerator = new NextIntegerGenerator(generator);

            var result = nextIntegerGenerator.NextBool();
            Assert.AreEqual(epectedResult, result);
        }
    }
}
