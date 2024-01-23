namespace Tests
{
    [TestClass]
    public class GetItemsWithBufferGeneratorTest
    {
        [TestMethod]
        [DataRow(new bool[] { true })]
        [DataRow(new bool[] { true, false })]
        [DataRow(new bool[] { true, false, true })]
        [DataRow(new bool[] { false })]
        [DataRow(new bool[] { false, false })]
        [DataRow(new bool[] { false, false, true })]
        public void GivenGetItemsTrue_WhenCallingNextBool_ThenExpectTheCorrectReturn(bool[] items)
        {
            var generator = Substitute.For<IRandomGenerator>();
            _ = generator.GetItems(Arg.Any<bool[]>(), Arg.Any<int>()).Returns(items);

            var boolGenerator = new GetItemsGenerator(generator);


            var length = 10;
            for (var i = 0; i < length; i++)
            {
                var expectedResult = items[0];
                Assert.AreEqual(expectedResult, boolGenerator.NextBool());
            }
        }
    }
}
