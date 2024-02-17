namespace Tests;

[TestClass]
public class GetItemsGeneratorTest
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

        var boolGenerator = new GetItemsWithBufferGenerator(generator, items.Length);

        var length = 10;
        for (var i = 0; i < length; i++)
        {
            var expectedIndex = i % items.Length;
            var expectedResult = items[expectedIndex];
            Assert.AreEqual(expectedResult, boolGenerator.NextBool());
        }
    }
}
