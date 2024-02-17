namespace Tests;

[TestClass]
public class NextBytesGeneratorTest
{
    [TestMethod]
    [DataRow((byte)0x34, "0010 1100")]
    [DataRow((byte)0x7E, "0111 1110")]
    [DataRow((byte)0xA5, "1010 0101")]
    public void GivenByte_WhenGeneratingBoolean_ThenExpectCorrectReturnValues(byte sourceByte, string bits)
    {
        var generator = Substitute.For<IRandomGenerator>();

        generator.When(x => x.NextBytes(Arg.Any<byte[]>())).Do(callInfo =>
        {
            var buffer = callInfo.Arg<byte[]>();
            buffer[0] = sourceByte;
        });

        var nextBytesGenerator = new NextBytesGenerator(generator, 1);
        var expected = bits.Replace(" ", "");

        var counter = 10;
        for (var i = 0; i < counter; i++)
        {
            var expectedIndex = i % 8;
            var expectedValue = expected[expectedIndex] == '1';

            Assert.AreEqual(expectedValue, nextBytesGenerator.NextBool());
        }
    }

    [TestMethod]
    [DataRow(new byte[] { 0x67, 0x50 }, "1110 0110 0000 1010")]
    [DataRow(new byte[] { 0xA1, 0x75 }, "1000 0101 1010 1110")]
    public void GivenTwoBytes_WhenGeneratingBoolean_ThenExpectCorrectReturnValues(byte[] sourceBytes, string bits)
    {
        var generator = Substitute.For<IRandomGenerator>();

        generator.When(x => x.NextBytes(Arg.Any<byte[]>())).Do(callInfo =>
        {
            var buffer = callInfo.Arg<byte[]>();
            buffer[0] = sourceBytes[0];
            buffer[1] = sourceBytes[1];
        });

        var nextBytesGenerator = new NextBytesGenerator(generator, 2);
        var expected = bits.Replace(" ", "");

        var counter = 10;
        for (var i = 0; i < counter; i++)
        {
            var expectedIndex = i % 16;
            var expectedValue = expected[expectedIndex] == '1';

            Assert.AreEqual(expectedValue, nextBytesGenerator.NextBool());
        }
    }
}
