namespace DeprecationTests
{
    [TestClass]
    public class DeprecationTest
    {
        [TestMethod]
        public void GivenInputString_WhenReverseString_Deprecated_ThenReturnReversedString()
        {
            string input = "Hello, World!";

            string reversed = StringUtils.ReverseString(input);

            Assert.AreEqual("!dlroW ,olleH", reversed);
        }

        [TestMethod]
        public void GivenInputString_WhenReverseStringV2_ThenReturnReversedString()
        {
            // Given
            string input = "Hello, World!";

            // When
            string reversedV2 = StringUtils.ReverseStringV2(input);

            // Then
            Assert.AreEqual("!dlroW ,olleH", reversedV2);
        }

    }
}