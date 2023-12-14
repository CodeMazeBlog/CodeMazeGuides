using ByteRepresentationOfStrings;

namespace Tests
{
    [TestClass]
    public class StringByteConverterTests
    {
        [TestMethod]
        public void GivenString_WhenToBytesConversion_ThenObtainCorrectBytes()
        {
            string inputString = "CodeMaze";
            byte[] expectedBytes = { 67, 0, 111, 0, 100, 0, 101, 0, 77, 0, 97, 0, 122, 0, 101, 0 };

            byte[] resultBytes = StringByteConverter.GetBytes(inputString);

            CollectionAssert.AreEqual(expectedBytes, resultBytes);
        }

        [TestMethod]
        public void GivenBytes_WhenToStringConversion_ThenObtainCorrectString()
        {
            byte[] inputBytes = { 67, 0, 111, 0, 100, 0, 101, 0, 77, 0, 97, 0, 122, 0, 101, 0 };
            string expectedString = "CodeMaze";

            string resultString = StringByteConverter.GetString(inputBytes);

            Assert.AreEqual(expectedString, resultString);
        }

        [TestMethod]
        public void GivenString_WhenToBytesAndBackConversion_ThenObtainOriginalString()
        {
            string inputString = "UnitTesting";

            byte[] resultBytes = StringByteConverter.GetBytes(inputString);
            string resultString = StringByteConverter.GetString(resultBytes);

            Assert.AreEqual(inputString, resultString);
        }

        [TestMethod]
        public void GivenNonAsciiString_WhenCafeWithNonAsciiChars_ThenObtainCorrectBytes()
        {
            string inputString = "Caféöäü€";
            byte[] expectedBytes = { 67, 0, 97, 0, 102, 0, 233, 0, 246, 0, 228, 0, 252, 0, 172, 32 };

            byte[] resultBytes = StringByteConverter.GetBytes(inputString);

            CollectionAssert.AreEqual(expectedBytes, resultBytes);
        }

        [TestMethod]
        public void GivenNonAsciiString_WhenToBytesAndBackConversion_ThenObtainOriginalString()
        {
            string expectedString = "Caféöäü€";

            byte[] resultBytes = StringByteConverter.GetBytes(expectedString);
            string resultString = StringByteConverter.GetString(resultBytes);

            Assert.AreEqual(expectedString, resultString);
        }
    }
}
