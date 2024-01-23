using System.Text;

namespace Tests
{
    [TestClass]
    public class NextIntegerBitsGeneratorTest
    {
        [TestMethod]
        [DataRow(0x12345678, "0001 1110 0110 1010 0010 1100 0100 1000")]
        [DataRow(0x674, "0010 1110 0110 0000 0000 0000 0000 0000")]
        [DataRow(0x13, "1100 1000 0000 0000 0000 0000 0000 0000")]
        [DataRow(0x7BCDEF98, "0001 1001 1111 0111 1011 0011 1101 1110")]
        [DataRow(int.MaxValue, "1111 1111 1111 1111 1111 1111 1111 1110")]
        public void GivenInteger_WhenGeneratingBoolean_ThenExpectCorrectReturnValues(int number, string bits)
        {
            // this test is only valid for little endian systems
            if (!BitConverter.IsLittleEndian)
                return;

            var generator = Substitute.For<IRandomGenerator>();
            _ = generator.NextInteger(Arg.Any<int>(), Arg.Any<int>()).Returns(number);

            var nextBytesGenerator = new NextIntegerBitsGenerator(generator);

            var result = new StringBuilder(32);
            for (var i = 0; i < 32; i++)
            {
                _ = result.Append(nextBytesGenerator.NextBool() ? '1' : '0');
            }

            var expected = bits.Replace(" ", "");
            var calculated = result.ToString();

            Assert.AreEqual(expected, calculated);
        }
    }
}
