using Deprecation;

namespace DeprecationTests
{
    [TestClass]
    public class DeprecationTest
    {
        [TestMethod]
        public void GivenInputString_WhenReverseString_Deprecated_ThenReturnReversedString()
        {
            var input = StringUtils.input;

            var reversed = StringUtils.ReverseString(input);

            Assert.AreEqual(StringUtils.reverseInput, reversed);
        }

        [TestMethod]
        public void GivenInputString_WhenReverseStringV2_ThenReturnReversedString()
        {
            var input = StringUtils.input;

            var reversedV2 = StringUtils.ReverseStringV2(input);

            Assert.AreEqual(StringUtils.reverseInput, reversedV2);
        }

    }
}